using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    float m_moveSpeed;
    Rigidbody2D m_Rigidbody;

    private void Awake()
    {
        if (m_Rigidbody = null)
            gameObject.AddComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        m_Rigidbody = gameObject.GetComponent<Rigidbody2D>();
        m_Rigidbody.gravityScale = 0;
        m_moveSpeed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        m_Rigidbody.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * m_moveSpeed, 0.8f), Mathf.Lerp(0, Input.GetAxis("Vertical") * m_moveSpeed, 0.8f));
    }
}