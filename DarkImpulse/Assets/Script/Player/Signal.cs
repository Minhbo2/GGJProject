using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hider")
        {
            Hider i_HiderScript;
            i_HiderScript = other.GetComponent<Hider>();
            i_HiderScript.Tagged = true;


        }
    }

}
