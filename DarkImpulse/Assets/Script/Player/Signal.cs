using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hider")
        {
            Renderer rend;
            rend = other.GetComponent<Renderer>();
            rend.material.color = Color.yellow;

        }
    }

}
