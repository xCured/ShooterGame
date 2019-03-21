using UnityEngine;
using UnityEngine.Networking;


public class NetworkShoots : NetworkBehaviour
{
    public PlayerWeapon weapons;
    [SerializeField]
    private Camera Cameras;
    [SerializeField]
    public LayerMask Layers;


    private void Start()
    {
        if (Cameras == null)
        {
            Debug.LogError("No cam ");
                this.enabled = false;
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown("fire1"))
        {
            Shoot();
        }
    }


    void Shoot()
    {
        //MuzzleFlash.Play();
        RaycastHit Ray;
        if (Physics.Raycast(Cameras.transform.position, Cameras.transform.forward, out Ray, weapons.range, Layers))
        {
            TargetShoots target = Ray.transform.GetComponent<TargetShoots>();
            if (target != null)
            {
               
            }

        }
    }
}
