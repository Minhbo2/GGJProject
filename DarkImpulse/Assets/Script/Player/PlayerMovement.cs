using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Rigidbody m_RigidBody;

	public float m_MoveSpeed;
    public float m_SignalSpeed;
    public float m_MaxSpeed;

    // Use this for initialization
    void Start ()
    {
		m_MoveSpeed = 10.0f;
        m_MaxSpeed = 250;
		m_RigidBody = GetComponent<Rigidbody> ();

        if (!m_RigidBody)
        {
           m_RigidBody = gameObject.AddComponent<Rigidbody>() as Rigidbody;
        }
    }

    private void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate ()
    {

        //if (m_RigidBody.velocity.sqrMagnitude < m_MaxSpeed)
        //{
        //    if (Input.GetKey(KeyCode.W))
        //    {
        //        m_RigidBody.velocity += Vector3.forward * m_MoveSpeed;
        //    }

        //    if (Input.GetKey(KeyCode.S))
        //    {
        //        m_RigidBody.velocity += Vector3.back * m_MoveSpeed;
        //    }

        //    if (Input.GetKey(KeyCode.A))
        //    {
        //        m_RigidBody.velocity += Vector3.left * m_MoveSpeed;
        //    }
        //    if (Input.GetKey(KeyCode.D))
        //    {
        //        m_RigidBody.velocity += Vector3.right * m_MoveSpeed;
        //    }

        //}

        float translation = Input.GetAxis("Vertical") * m_MoveSpeed;
        float translation1 = Input.GetAxis("Horizontal") * m_MoveSpeed;
        translation *= Time.deltaTime;
        translation1 *= Time.deltaTime;
        transform.Translate(translation1, 0, 0);
        transform.Translate(0, 0, translation);

    }

}
