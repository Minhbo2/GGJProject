using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetection : MonoBehaviour {

    private Renderer m_playerColor;

	// Use this for initialization
	void Start () {
        m_playerColor = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Debug.Log("Collided");
            m_playerColor.material = Resources.Load("NPC/Material/testMat_2") as Material;
            StartCoroutine(loseDetection());
        }
    }

    IEnumerator loseDetection()
    {
        yield return new WaitForSeconds(1);
        m_playerColor.material = Resources.Load("NPC/Material/testMat_1") as Material;
    }
}
