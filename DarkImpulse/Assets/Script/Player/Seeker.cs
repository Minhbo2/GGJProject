using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour {

    GameObject Signal;
    float m_SignalSpeed;
    // Use this for initialization
    void Start () {
        m_SignalSpeed = 1.02f;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Start scaling");
            if (Signal == null)
                Signal = Instantiate(Resources.Load("Player/Animation/SeekerSignal", typeof(GameObject)) as GameObject);

            Signal.transform.position = gameObject.transform.position;
            Signal.transform.localScale *= m_SignalSpeed;
        }
    }
}
