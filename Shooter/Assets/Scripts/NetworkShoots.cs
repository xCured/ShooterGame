using UnityEngine;
using UnityEngine.Networking;


public class NetworkShoots : NetworkBehaviour
{
    public PlayerWeapon weapons;
    [SerializeField]
    private Camera Cameras;
    [SerializeField]
    public LayerMask Layers;

   

     void Start()
    {
        if (Cameras == null)
        {
            Debug.LogError("No cam ");
                this.enabled = false;
        }
    }

     void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    [Client]
    void Shoot()
    {

        
        //MuzzleFlash.Play();
        RaycastHit Ray;
        if (Physics.Raycast(Cameras.transform.position, Cameras.transform.forward, out Ray, weapons.range))
        {
            if (Ray.transform.tag == "Player" )
            {
                Debug.Log("You hit something");
                CmdPlayerShot(Ray.collider.name, weapons.damage);
            }
        }
        //The raycast checks if they locally hit something which they have, they send that information over to the 'command' section which is the server
        //Takes into consideration what we hit, and some damge 
        //Gets passed to the server [2]
        }

    [Command]
    void CmdPlayerShot(string playerID, int _Damage)
    {
        Debug.Log(playerID + "player shot");
       
      PlayerManager _Player =  GameManager.GetPlayer(playerID);
        _Player.Damage(_Damage);
        //[2] the server takes the information about hte playerid, finds the player component by using the gamemanager which tracks different players.
        //takes damage variable which puts a damage variable 
        //Since the currenthealth is synced  it locally checks if the health is reduced which syncs it to all clients. 
    }
}
