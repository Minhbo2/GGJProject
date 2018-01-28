using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetection : MonoBehaviour {
    GameObject Signal;
    bool wait;
    bool wait1;
    //How fast will the speed travel
    float m_SignalSpeed;

    //How long to scale signal for
    float ScaleTime;

    bool TransmitReady;
    bool StillIn;

	AudioSource sonarSound;
	public AudioClip sonarHitClip;
	public AudioClip WallHit;
	public AudioClip HidersCollide;
	public AudioClip sonarClip;

    // Use this for initialization
    void Start()
    {
        wait = false;
        m_SignalSpeed = 1.1f;
        ScaleTime = .35f;
        StillIn = false;
        wait1 = true;
        sonarSound = GetComponent<AudioSource>();

    }


    // Update is called once per frame
    void Update()
    {

        if (TransmitReady)
        {
            Signal.transform.position = gameObject.transform.position;

            if(wait1)
            {
                StartCoroutine("WaitSecs");
                wait1 = false;
            }

            Vector3 currentScale = Signal.transform.localScale;
            Signal.transform.localScale = new Vector3(currentScale.x * m_SignalSpeed, currentScale.y++, currentScale.z * m_SignalSpeed);
        }

    }
    IEnumerator WaitSecs()
    {
        sonarSound.clip = sonarClip;
        sonarSound.Play();
        yield return new WaitForSeconds(1.25f);
        wait1 = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Signal" && gameObject.tag != "Seeker")
        {
            BlipBack();
			sonarSound.clip = sonarHitClip;
			sonarSound.Play ();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            BlipBack();
			sonarSound.clip = WallHit;
			sonarSound.Play ();

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

			if (collision.gameObject.tag == "Hider")
			{
				sonarSound.clip = HidersCollide;
				sonarSound.Play ();
			}

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

		sonarSound.clip = sonarClip;
		sonarSound.pitch = 1.5f;
		sonarSound.Play ();
		sonarSound.pitch = 1.0f;
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
