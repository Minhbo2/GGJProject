using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetection : MonoBehaviour {
    GameObject Signal;
    bool wait;
    //How fast will the speed travel
    float m_SignalSpeed;

    //How long to scale signal for
    float ScaleTime;

    bool TransmitReady;
    bool StillIn;
    // Use this for initialization
    void Start()
    {
        wait = false;
        m_SignalSpeed = 1.1f;
        ScaleTime = .35f;
        StillIn = false;
    }


    // Update is called once per frame
    void Update()
    {

        if (TransmitReady)
        {
            Signal.transform.position = gameObject.transform.position;

            Vector3 currentScale = Signal.transform.localScale;
            Signal.transform.localScale = new Vector3(currentScale.x * m_SignalSpeed, currentScale.y++, currentScale.z * m_SignalSpeed);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Signal" && gameObject.tag != "Seeker")
        {
            BlipBack();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            BlipBack();

        }
    }

    private void OnCollisionStay(Collision collision)
    {

        Debug.Log("asdasd");
        if (wait == false)
        {
            StillIn = true;
            wait = true;
        }

        if ((collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Hider") && StillIn == true)
        {
            StillIn = false;
            if (Signal == null)
                Signal = Instantiate(Resources.Load("Player/Animation/SeekerSignal", typeof(GameObject)) as GameObject);

            StartCoroutine(TransmitSignal(ScaleTime));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        StillIn = false;
    }

    void BlipBack()
    {
        if (Signal == null)
            Signal = Instantiate(Resources.Load("Player/Animation/SeekerSignal", typeof(GameObject)) as GameObject);

        StartCoroutine(TransmitSignal(ScaleTime));
    }

    IEnumerator TransmitSignal(float time)
    {
        TransmitReady = true;
        yield return new WaitForSeconds(time);
        TransmitReady = false;
        wait = false;
        Destroy(Signal);
    }



}
