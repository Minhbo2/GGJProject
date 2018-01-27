
using UnityEngine.Networking;
using UnityEngine;

public class SetupLocalPlayer : NetworkBehaviour
{
    [SyncVar]
    public string playerName;
    [SyncVar]
    public Color playerColor;
    [SyncVar]
    public int lobbyAssignFlag;

    [SerializeField]
    private GameObject tagComponent;
    [SerializeField]
    private GameObject detectionComponent;
    [SerializeField]
    private GameObject locationNotification;
    [SerializeField]
    private float minBoxBound;
    [SerializeField]
    private float maxBoxBound;
    [SerializeField]
    private float sphereCastRadius;


    private int SeekerFlag         = 1;
    private Vector3 seekerPosition = new Vector3(0, 0, 0);


    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            //Enable Movement script
<<<<<<< HEAD
            PlayerMovement s_MovementScript = GetComponent<PlayerMovement>();
            s_MovementScript.enabled = true;
            
=======
            PlayerMovement s_MovementScript;
            s_MovementScript = GetComponent<PlayerMovement>();
            s_MovementScript.enabled = true;
>>>>>>> PlayerNetwork

            Renderer renderer = GetComponent<Renderer>();
            renderer.material.color = playerColor;
            this.gameObject.name = playerName;
            if (IsSeeker())
            {
                ManageComponent(tagComponent);
                ManageComponent(detectionComponent);
            }
            else
                ManageComponent(locationNotification);

            SetLocalPlayerPosition();
        }
    }



    private bool IsSeeker()
    {
        return (lobbyAssignFlag == SeekerFlag);
    }




    private void ManageComponent(GameObject component)
    {
        if (component == null)
        {
            print("missing component!");
            return;
        }
        component.SetActive(true);
    }



    private void SetLocalPlayerPosition()
    {
        if (IsSeeker())
        {
            transform.position = seekerPosition;
            return;
        }

        //TODO:
        //Set a random point around the seeker
        bool hasEmptyLocation = false;
        while (!hasEmptyLocation)
        {
            var randPosition = RandomPointInLevel();
            hasEmptyLocation = IsEmpty(randPosition);
            if (hasEmptyLocation)
            {
                transform.position = randPosition;
                return;
            }
        }
        
    }


    private bool IsEmpty(Vector3 castAtLocation)
    {
        Ray ray = new Ray(castAtLocation, Vector3.zero);
        RaycastHit hitInfo;
        bool didHit = Physics.SphereCast(ray, sphereCastRadius, out hitInfo);
        if (didHit)
            print(hitInfo.collider.name);
        return !didHit;
    }


    private Vector3 RandomPointInLevel()
    {
        float randX = Random.Range(minBoxBound, maxBoxBound);
        float randY = Random.Range(minBoxBound, maxBoxBound);
        return new Vector3(randX, randY, 0);
    }
}