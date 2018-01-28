using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarAbility : MonoBehaviour {

    private float m_sonarRadius;
    private bool m_activatedAbility;
    private float m_cooldown;
    private GameObject m_sonarAnimation;

    private WallDetection m_WallDetection;

	// Use this for initialization
	void Start () {
        m_sonarAnimation = transform.GetChild(1).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(m_activatedAbility)
        {
            m_sonarRadius += 0.5f;
            Debug.Log(m_sonarRadius);
        }
	}

    private void FixedUpdate()
    {
        RaycastHit2D[] hit2D = Physics2D.CircleCastAll(gameObject.transform.position, m_sonarRadius, Vector2.zero);
        m_sonarAnimation.transform.localScale = new Vector3(m_sonarRadius + 1, m_sonarRadius + 1, 1);

        foreach(RaycastHit2D enemy in hit2D)
        {
            m_WallDetection = enemy.collider.GetComponent<WallDetection>();
            //m_WallDetection.PlayerDetected();
        }

        if(Input.GetKey(KeyCode.Z))
        {
            if (m_cooldown < Time.timeSinceLevelLoad)
            {
                gameObject.layer = 2;
                m_cooldown = Time.timeSinceLevelLoad + 10;
                m_activatedAbility = !m_activatedAbility;
                StartCoroutine(AbilityActivated());
            }
        }
    }

    IEnumerator AbilityActivated()
    {
        yield return new WaitForSeconds(2);
        m_activatedAbility = !m_activatedAbility;
        m_sonarRadius = 0.0f;
        gameObject.layer = 0;
    }
}
