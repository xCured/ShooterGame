
using UnityEngine;

public class Gunscript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public ParticleSystem MuzzleFlash;

    public Camera FPSCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            Debug.Log(damage);
        }
    }

    void Shoot()
    {
        MuzzleFlash.Play();
        RaycastHit Ray;
       if( Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out Ray, range))
        {
            TargetShoots target = Ray.transform.GetComponent<TargetShoots>();
            if(target !=null)
            {
                target.takeDmg(damage);
            }
            
        }
    }

}
