using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour {


    PlayerMovement s_PlayerMovement;

    GameObject Signal;

    //How fast will the speed travel
    float m_SignalSpeed;

    //How long to get signal ability again
    float m_SignalCooldown;

    //How long to scale signal for
    float ScaleTime;

	AudioSource sonarSound;
	public AudioClip sonarClip;

    private void Awake()
    {

        if (gameObject.GetComponent<AudioSource>() != true)
            sonarSound = gameObject.AddComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        Signal = null;

        m_SignalSpeed = 1.075f;
        m_SignalCooldown = 0f;
        ScaleTime = 1.5f;

    }
	
	// Update is called once per frame
	void Update () {

        if (m_SignalCooldown != 0f)
        {
            m_SignalCooldown -= Time.deltaTime;
            Signal.transform.position = gameObject.transform.position;
            Vector3 currentScale = Signal.transform.localScale;
            Signal.transform.localScale = new Vector3(currentScale.x * m_SignalSpeed, currentScale.y++, currentScale.z * m_SignalSpeed) ;
        }


        if (Input.GetKeyDown(KeyCode.Space) && m_SignalCooldown == 0f)
        {
            if (Signal == null)
                Signal = ResourcesManager.Create("Player/Animation/SeekerSignal");


			if (sonarClip != null)
			{
				sonarSound.clip = sonarClip;
				sonarSound.pitch = .75f;
				sonarSound.Play ();

			} else
			{
				Debug.Log ("failed to find audio clip");
			}

            m_SignalCooldown = 5f;

            StartCoroutine(SignalCooldown(m_SignalCooldown));

            StartCoroutine(TransmitSignal(ScaleTime));

        }
       // Debug.Log(m_SignalCooldown);
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Hider")
		{
			Destroy (other.gameObject, 2f);
		}
	}

    IEnumerator SignalCooldown(float timer)
    {
        yield return new WaitForSeconds(timer);
        m_SignalCooldown = 0f;
    }

    IEnumerator TransmitSignal(float time)
    {    
        yield return new WaitForSeconds(time);

        Destroy (Signal);
    }
}
