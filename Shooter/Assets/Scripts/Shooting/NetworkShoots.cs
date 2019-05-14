using UnityEngine;
using UnityEngine.Networking;


public class NetworkShoots : NetworkBehaviour
{
    public PlayerWeapon weapons;
    [SerializeField]
    private Camera Cameras;
    [SerializeField]
    public LayerMask Layers;

    //decal
    public GameObject Decal;

    
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
    public void Shoot()
    {


        //MuzzleFlash.Play();
        RaycastHit RayHit;
        Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(Cameras.transform.position, Cameras.transform.forward, out RayHit, weapons.range))
        {
            if (RayHit.transform.tag == "Player")
            {
                Debug.Log("You hit something");

                CmdPlayerShot(RayHit.collider.name, weapons.damage);
            }

            if (RayHit.transform.tag == "Walls")
            {
                RayHit.collider.GetComponent<Rigidbody>().isKinematic = false;


                RayHit.collider.GetComponent<Rigidbody>().AddForce(3, 3, 2 * 4, ForceMode.Impulse);

            }
            if (Physics.Raycast(Ray, out RayHit))
            {
                SpawnDecals(RayHit);

            }

        }


        //The raycast checks if they locally hit something which they have, they send that information over to the 'command' section which is the server
        //Takes into consideration what we hit, and some damge 
        //Gets passed to the server [2]
    }

    public void SpawnDecals(RaycastHit RayHit)
    {
        var decals = Instantiate(Decal);
        decals.transform.position = RayHit.point;
        decals.transform.forward = RayHit.normal * -1f;
    }



    [Command]
    void CmdPlayerShot(string playerID, int _Damage)
    {
        Debug.Log(playerID + "player shot");
       
      PlayerManager _Player =  GameManager.GetPlayer(playerID);
        _Player.RpcDamage(_Damage);
        //[2] the server takes the information about hte playerid, finds the player component by using the gamemanager which tracks different players.
        //takes damage variable which puts a damage variable 
        //Since the currenthealth is synced  it locally checks if the health is reduced which syncs it to all clients. 
    }
}
