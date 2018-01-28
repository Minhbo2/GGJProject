using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Rigidbody m_RigidBody;

	public float m_MoveSpeed;
    public float m_SignalSpeed;
    public float m_MaxSpeed;


    private string horizontalAxis;
    private string verticalAxis;

    public GameObject childSpotlight;
    // Use this for initialization
	

    void Start ()
    {
		m_MoveSpeed = 10.0f;
        m_MaxSpeed = 250;
		m_RigidBody = GetComponent<Rigidbody> ();
        Renderer ren = GetComponent<Renderer>();

        if (!m_RigidBody)
        {
           m_RigidBody = gameObject.AddComponent<Rigidbody>() as Rigidbody;
        }

        if (GetComponent<Seeker>().enabled == false)
        {
			if (gameObject.name == "Player_Bot1")
			{
				gameObject.tag = "Hider";
				horizontalAxis = "ArrowHorizontal";
				verticalAxis = "ArrowVertical";
				childSpotlight.SetActive(false);
			} else if (gameObject.name == "Player_Bot2")
			{
				gameObject.tag = "Hider";
				horizontalAxis = "ArrowHorizontal2";
				verticalAxis = "ArrowVertical2";
				childSpotlight.SetActive(false);
			} else if (gameObject.name == "Player_Bot3")
			{
				gameObject.tag = "Hider";
				horizontalAxis = "ArrowHorizontal3";
				verticalAxis = "ArrowVertical3";
				childSpotlight.SetActive(false);
			}
           
        }
        else
        {
            horizontalAxis = "Horizontal";
            verticalAxis = "Vertical";
            childSpotlight.SetActive(true);

        }
    }



    // Update is called once per frame
    void FixedUpdate ()
    {
        float translation = Input.GetAxis(verticalAxis) * m_MoveSpeed;
        float translation1 = Input.GetAxis(horizontalAxis) * m_MoveSpeed;
        translation *= Time.deltaTime;
        translation1 *= Time.deltaTime;
        this.transform.Translate(translation1, 0, 0);
        this.transform.Translate(0, 0, translation);
    }

}
