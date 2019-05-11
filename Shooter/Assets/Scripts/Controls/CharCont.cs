using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCont : MonoBehaviour
{



    private float speed = 12f;
    private PlayerMot Motor;
    
    private float MouseSens = 2f;
    
    private float MouseSensY = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Motor = GetComponent<PlayerMot>();
    }
    
    // Update is called once per frame
    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");


        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;

        Vector3 _Velocity = (movHorizontal + movVertical).normalized * speed;

        Motor.Move(_Velocity);


        float yRot = Input.GetAxis("Mouse X");


        Vector3 _rotation = new Vector3(0f, yRot, 0f) * MouseSensY;

        Motor.Rotate(_rotation);




        float xRot = Input.GetAxis("Mouse Y");


        float  _CameraRotationX = xRot * MouseSens;

        Motor.RotateCamera(_CameraRotationX);
    }
}
