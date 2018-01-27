using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float m_moveSpeed;
    Rigidbody2D m_Rigidbody;

	// Use this for initialization
	void Start () {
        m_Rigidbody = gameObject.GetComponent<Rigidbody2D>();
        m_moveSpeed = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            m_Rigidbody.velocity += Vector2.left * m_moveSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            m_Rigidbody.velocity += Vector2.up * m_moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_Rigidbody.velocity += Vector2.down * m_moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_Rigidbody.velocity += Vector2.right * m_moveSpeed;
        }
    }
}
