using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{

    public Animator animatorController;
    public float distance;
    public float speed;

    private Rigidbody rb;
    public Transform hips;

    public GameObject floor;
    public CharacterUpright torso;

    public float rotateSpeed;

    Vector3 rotationLeft;
    Vector3 rotationRight;

    void Start()
    {	// sphere
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        distance = Vector3.Distance(rb.transform.position, floor.transform.position);
    }

    void FixedUpdate()
    {
       

        #region ground detection layer 2

        //if player distance is far away from the floor disable character upright script.
        if (distance > 15)
        {
            torso.enabled = false;
        }

        else if (distance < 15)
        {
            torso.enabled = true;
        }
        #endregion
    }
}