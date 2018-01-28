using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	private int m_seconds;
	private int m_minutes;

	private bool m_isCountingDown;

	public Text timerText;
	void Start () {
		m_minutes = 2;
		m_isCountingDown = !m_isCountingDown;
		StartTimer();
	}

	void Update()
	{
		timerText.text = m_minutes + " Min " + m_seconds.ToString("00") + " Sec";
		if((m_seconds == 0) &&(m_minutes == 0))
		{
            if (GameObject.FindGameObjectsWithTag("Hider") != null)
            {
                timerText.text = "Hiders were able to evade the Seeker. Hiders Win.";
            }
            else
            {
                timerText.text = "Seekers were able to destroy the Hiders. Seekers Win.";

            }
        }	
	}


	// Starts the timer
	// Call this function in order to start the timer
	public void StartTimer()
	{
		StartCoroutine(CountdownTimer());
	}

	IEnumerator CountdownTimer()
	{
		while(m_isCountingDown)
		{
			yield return new WaitForSeconds(1);
			if((m_seconds == 0) &&(m_minutes == 0))
			{
				m_isCountingDown = !m_isCountingDown;
				yield return null;
			}
			else if(m_seconds == 0)
			{
				m_seconds = 59;
				m_minutes--;
			}
			else
				m_seconds--;
		}
	}
}