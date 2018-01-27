using UnityEngine;

public class TagComponent : MonoBehaviour {

    [SerializeField]
    private float expandAmount;
    [SerializeField]
    private float sweepMaxSize;


    private CircleCollider2D sweepCircle;





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Hider")
            return;

        print("Found a hider!");
        //TODO: 
        // expand the radius of the circle 
        ExpandSweepArea();
        SetHiderPositionNotification();
        //Grab the hider position notifier and activate it
    }


    private void ExpandSweepArea()
    {
        if (HasSweepCircle())
        {
            float currentSweepSize = sweepCircle.radius;
            if(currentSweepSize < sweepMaxSize)
                sweepCircle.radius += expandAmount;
        }
    }


    private bool HasSweepCircle()
    {
        sweepCircle = GetComponent<CircleCollider2D>();
        return (sweepCircle != null);
    }


    private void SetHiderPositionNotification()
    {

    }
}
