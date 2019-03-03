using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMot : MonoBehaviour
{

    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 CameraRotation = Vector3.zero;



    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 _Velocity)
    {
        velocity = _Velocity;
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }
    public void RotateCamera(Vector3 _CameraRotation)
    {
        CameraRotation = _CameraRotation;
    }

    //runs every physics iteration
    void FixedUpdate()
    {
        DoMovement();
        DoRotate();
    }

    void DoMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
        }
    }

    void DoRotate()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if(cam != null)
        {
            cam.transform.Rotate(-CameraRotation);
        }
    }
}
