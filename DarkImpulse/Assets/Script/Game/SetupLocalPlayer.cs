
using UnityEngine.Networking;
using UnityEngine;

public class SetupLocalPlayer : NetworkBehaviour
{
    [SyncVar]
    public string playerName;
    [SyncVar]
    public Color playerColor;

    [SerializeField]
    private float minBoxBound;
    [SerializeField]
    private float maxBoxBound;
    [SerializeField]
    private float sphereCastRadius;
    [SerializeField]
    private GameObject light;


    private Seeker seekerScript;
    private int seekerFlag                = 1;
    private Vector3 seekerPosition        = new Vector3(0, 0, 0);


    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            //Enable Movement script
            PlayerMovement s_MovementScript = GetComponent<PlayerMovement>();
            s_MovementScript.enabled        = true;

            InitLocalPlayer();

            Renderer ren = GetComponent<Renderer>();
            if (this.IsSeeker())
            {
                seekerScript = GetComponent<Seeker>();
                seekerScript.enabled = true;
                light.SetActive(true);
            }
            else
                ren.material.color = Color.green;
        }

        if (IsSeeker())
        {
            light.SetActive(true);
        }
    }



    private bool IsSeeker()
    {
        int rand = Random.Range(0, 5);
        return(rand == seekerFlag);
    }





    private void InitLocalPlayer()
    {
        if (IsSeeker())
        {
            transform.position = seekerPosition;
            return;
        }


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
        print(castAtLocation);
        Ray ray = new Ray(castAtLocation, Vector3.zero);
        RaycastHit hitInfo;
        bool didHit = Physics.SphereCast(ray, sphereCastRadius, out hitInfo);
        return !didHit;
    }


    private Vector3 RandomPointInLevel()
    {
        float randX = Random.Range(minBoxBound, maxBoxBound);
        float randZ = Random.Range(minBoxBound, maxBoxBound);
        return new Vector3(randX, 0, randZ);
    }
}