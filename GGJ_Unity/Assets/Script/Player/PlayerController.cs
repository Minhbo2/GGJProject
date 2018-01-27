using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody m_RigidBody;

	float m_MoveSpeed;
	void Awake () 
	{
		if (!m_RigidBody) 
		{
			m_RigidBody = gameObject.GetComponent<Rigidbody> ();
		}

	}

	// Use this for initialization
	void Start () {
		m_MoveSpeed = 1.0f;
		m_RigidBody = gameObject.GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

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
		if (Input.GetKey (KeyCode.Space)) 
		{
			m_RigidBody.velocity += Vector3.up * m_MoveSpeed;
		}
	}
}
