using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(PlayerManager))]
public class Setup : NetworkBehaviour {

    //create list of components to disable since everything is in behaviour. we create array
    [SerializeField]
    Behaviour[] componentsDisable;

    string remoteLayers = "Remote";
    Camera cams;



    private void Start()
    {
        //check if we are the local player.
        if (!isLocalPlayer)
        {
            //checks if we are controlling the player, if not we disable components. we loop through list
            //we set the enable state to false to disable it. 
            //same has to be done through camera
            DisableOnStart();
            RemotePlayer();
            //registerplayer();
        }
        else
        {
            cams = Camera.main;
            if (cams != null)
            {
                cams.gameObject.SetActive(false);
            }
        }
        GetComponent<PlayerManager>().Setup();

    }

    
    public void DisableOnStart()
    {
        for (int x = 0; x < componentsDisable.Length; x++)
        {
            componentsDisable[x].enabled = false;
        }
    }

    void RemotePlayer()
    {
        //the problem was gameobject wants an integer value as layers are asigned numbers.
        gameObject.layer = LayerMask.NameToLayer(remoteLayers);
    }
    private void OnDisable()
    {
        if (cams !=null){
            cams.gameObject.SetActive(true);
        }

        GameManager.Unregister(transform.name);
    }

   


    //Runs everytime a client is set up locally 
   
    public override void OnStartClient()
    {
        base.OnStartClient();

        string netID = GetComponent<NetworkIdentity>().netId.ToString();
        PlayerManager Players = GetComponent<PlayerManager>();

        GameManager.PlayerRegistration(netID, Players);
    }
}
