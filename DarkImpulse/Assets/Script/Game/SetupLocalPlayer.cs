
using UnityEngine.Networking;
using UnityEngine;

public class SetupLocalPlayer : NetworkBehaviour
{
    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            print(this.transform.name + " is local player");
            //TODO: 
            //enable movement script
        }
    }

}