using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlayerManager : NetworkBehaviour
{   
    [SerializeField]
    public GameObject[] RespawnPoint;

    [SyncVar]
    private bool _Dead = false;
    public bool Dead
    {
       
        get { return _Dead;  }
        [SerializeField]
        protected set { _Dead = value; }
    }

    private int maxHealth = 100;

    [SerializeField]
    private Behaviour[] OnDeathDisable;
    private bool[] IsEnabled;

    [SyncVar] //Syncs the current health to all clients. This was quite difficult to find since everything is obsolete. 
   private int currentHealth;
   

    // Start is called before the first frame update
    //Changed to Setup because of method that was done on respawn
    public void Setup()
    {
       

        IsEnabled = new bool[OnDeathDisable.Length];
        for (int i = 0; i < IsEnabled.Length; i++)
        {
            IsEnabled[i] = OnDeathDisable[i].enabled;
        }

        SetDefaults();
    }
  


    public void SetDefaults()
    {

        Dead = false;
        currentHealth = maxHealth;

        for(int i = 0; i< OnDeathDisable.Length; i++)
        {
            OnDeathDisable[i].enabled = IsEnabled[i];
        }


        //Collider _col = GetComponent<Collider>();
        //if(_col != null)
        //{
        //    _col.enabled = true;
        //}
    }
    [ClientRpc]
    public void RpcDamage(int amount)
    {
        if (Dead)
            return;

        currentHealth -= amount;

      

        if(currentHealth <= 0)
        {
            Respawn();
        }

    }

   private void Respawn()
    {
       
        Dead = true;
        //Disable stuff so you cant move when dead.
        for (int i = 0; i < OnDeathDisable.Length; i++)
        {
            OnDeathDisable[i].enabled = false;
        }


        //Collider _col = GetComponent<Collider>();
        //if (_col != null)
        //{ 
        //    _col.enabled = false; 
        //}

        StartCoroutine(Respawning());
      
    }

    IEnumerator Respawning()
    {
        yield return new WaitForSeconds(3f);
        SetDefaults();
        Transform SpawnPoint = NetworkManager.singleton.GetStartPosition();
       // RespawnPoint.transform.position   = SpawnPoint.position;
       // transform.position = SpawnPoint.position;
        // s transform.position = SpawnPoint.position;
        //RespawnPoint.transform.rotation = SpawnPoint.rotation;
        for (int i = 0; i < RespawnPoint.Length; i++)
        {
            RespawnPoint[i].transform.rotation = SpawnPoint.rotation;
            RespawnPoint[i].transform.position = SpawnPoint.position;

        }
       // transform.rotation = SpawnPoint.rotation;
    }


}
