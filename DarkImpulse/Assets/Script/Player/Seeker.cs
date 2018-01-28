using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour {

<<<<<<< HEAD
    PlayerMovement s_PlayerMovement;
=======
>>>>>>> wall
    GameObject Signal;

    //How fast will the speed travel
    float m_SignalSpeed;

    //How long to get signal ability again
    float m_SignalCooldown;

    //How long to scale signal for
    float ScaleTime;

<<<<<<< HEAD
    //Custom speed variables in inspector apart from player movement script, so you dont have to touch playermovement script
    public float CustomSeekerSpeed;
    public float CustomMaxSeekerSpeed;

    bool TransmitReady;
    // Use this for initialization
    void Start () {
        s_PlayerMovement = GetComponent<PlayerMovement>();

        if (CustomMaxSeekerSpeed != 0)
        s_PlayerMovement.m_MaxSpeed = CustomMaxSeekerSpeed;

        if (CustomSeekerSpeed != 0)
        s_PlayerMovement.m_MoveSpeed = CustomSeekerSpeed;
=======
    bool TransmitReady;
    // Use this for initialization
    void Start () {
        Signal = null;
>>>>>>> wall

        m_SignalSpeed = 1.075f;
        m_SignalCooldown = 0f;
        ScaleTime = 1f;
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
<<<<<<< HEAD
                Signal = Instantiate(Resources.Load("Player/Animation/SeekerSignal", typeof(GameObject)) as GameObject);
=======
                Signal = ResourcesManager.Create("Player/Animation/SeekerSignal");
>>>>>>> wall

            m_SignalCooldown = 15f;

            StartCoroutine(SignalCooldown(m_SignalCooldown));

            StartCoroutine(TransmitSignal(ScaleTime));

        }
<<<<<<< HEAD


       // Debug.Log(m_SignalCooldown);
=======
>>>>>>> wall
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
<<<<<<< HEAD
=======
        
>>>>>>> wall
    }
}
