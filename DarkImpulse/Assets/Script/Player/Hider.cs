using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hider : MonoBehaviour {

    public bool Tagged;

    PlayerMovement s_PlayerMovement;

    public float CustomHiderSpeed;
    public float CustomMaxHiderSpeed;

    public Material YellowEmissive;
    public Material DefaultMat;

    // Use this for initialization
    void Start () {
        Tagged = false;
        DefaultMat = GetComponent<Renderer>().material;

        s_PlayerMovement = GetComponent<PlayerMovement>();

        if (CustomMaxHiderSpeed != 0)
            s_PlayerMovement.m_MaxSpeed = CustomMaxHiderSpeed;

        if (CustomHiderSpeed != 0)
            s_PlayerMovement.m_MoveSpeed = CustomHiderSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        if (Tagged)
        {
            StartCoroutine("TaggedBlip");
        }
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Seeker")
        {
            //Destroy(gameObject);
            StartCoroutine("Destroynow");

        }
    }

    IEnumerator TaggedBlip()
    {

        Renderer rend;
        rend = GetComponent<Renderer>();
        rend.material = YellowEmissive;
        rend.material.color = Color.yellow;
        Debug.Log("Seen!");
        rend.material.SetColor("_EmissionColor", Color.yellow);
        yield return new WaitForSeconds(3f);

        rend.material.color = Color.white;
        rend.material = DefaultMat;
        Tagged = false;


    }

    IEnumerator Destroynow()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
