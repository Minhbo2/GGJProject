using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetection : MonoBehaviour {

    private Renderer m_playerColor;

    private bool m_hasCollided;

	// Use this for initialization
	void Start () {
        m_playerColor = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(m_hasCollided)
        {
            m_hasCollided = false;
            Debug.Log("Collided");
            m_playerColor.material = Resources.Load("NPC/Material/testMat_2") as Material;
            StartCoroutine(loseDetection());
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject)
        {
            PlayerDetected();
        }
    }


    IEnumerator loseDetection()
    {
        yield return new WaitForSeconds(1);
        m_playerColor.material = Resources.Load("NPC/Material/testMat_1") as Material;
    }

    // Call this function to activate notification
    public void PlayerDetected()
    {
        m_hasCollided = true;
    }
}
