using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody m_RigidBody;

	public float m_MoveSpeed;

    public float m_MaxSpeed;
	// Use this for initialization
	void Start () {
		m_MoveSpeed = 1.0f;
        m_MaxSpeed = 250;
		m_RigidBody = GetComponent<Rigidbody> ();

        if (!m_RigidBody)
        {
           m_RigidBody = gameObject.AddComponent<Rigidbody>() as Rigidbody;
        }

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (m_RigidBody.velocity.sqrMagnitude < m_MaxSpeed)
        {
            if (Input.GetKey(KeyCode.W))
            {
                m_RigidBody.velocity += Vector3.forward * m_MoveSpeed;
            }

            if (Input.GetKey(KeyCode.S))
            {
                m_RigidBody.velocity += Vector3.back * m_MoveSpeed;
            }

            if (Input.GetKey(KeyCode.A))
            {
                m_RigidBody.velocity += Vector3.left * m_MoveSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                m_RigidBody.velocity += Vector3.right * m_MoveSpeed;
            }
            Debug.Log(m_RigidBody.velocity.sqrMagnitude);

        }



		
	}
}
