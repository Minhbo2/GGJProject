
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

    private int SeekerFlag = 1;

    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            //TODO: 
            //enable movement script
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
}