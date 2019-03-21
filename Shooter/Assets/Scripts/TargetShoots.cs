
using UnityEngine;

public class TargetShoots : MonoBehaviour
{
    //health variable
    public float health = 100f;
    public void takeDmg(float damageAmount)
    {
        health -= damageAmount;
        if(health<= 0f)
        {
            dead();
        }
    }
    void dead()
    {
        Destroy(gameObject);
    }
}
