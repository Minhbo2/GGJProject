using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Seeker")
        {
            //Destroy(gameObject);
            StartCoroutine("Destroynow");

        }
    }


    IEnumerator Destroynow()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
