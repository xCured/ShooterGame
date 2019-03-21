
using UnityEngine;

public class Gunscript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 1000f;
    //public ParticleSystem MuzzleFlash;

    public Camera Cameras;


  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            Debug.Log(damage);
        }
        Debug.DrawRay(Cameras.transform.position, Cameras.transform.forward, Color.green);
    }

    void Shoot()
    {
        //MuzzleFlash.Play();
        RaycastHit Ray;
       if( Physics.Raycast(Cameras.transform.position, Cameras.transform.forward, out Ray, range))
        {
            TargetShoots target = Ray.transform.GetComponent<TargetShoots>();
            if(target !=null)
            {
                target.takeDmg(damage);
            }
            
        }
    }

}
