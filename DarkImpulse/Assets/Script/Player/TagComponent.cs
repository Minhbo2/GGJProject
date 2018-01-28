using UnityEngine;

public class TagComponent : MonoBehaviour {

    [SerializeField]
    private float expandSweepByAmound;

    private CircleCollider2D sweepCircle;

    private WallDetection m_WallDetection;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Hider")
            return;

        print("Found a hider!");
        m_WallDetection = collision.GetComponent<WallDetection>();
        //TODO: 
        // expand the radius of the circle 
        ExpandSweepArea();
        SetHiderPositionNotification();
        //Grab the hider position notifier and activate it
    }


    private void ExpandSweepArea()
    {
        if (HasSweepCircle())
            sweepCircle.radius += expandSweepByAmound;
    }


    private bool HasSweepCircle()
    {
        sweepCircle = GetComponent<CircleCollider2D>();
        return (sweepCircle != null);
    }


    private void SetHiderPositionNotification()
    {
        //m_WallDetection.PlayerDetected();
    }
}
