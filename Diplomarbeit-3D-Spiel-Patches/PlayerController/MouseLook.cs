using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    /*   public enum RotationAxes {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }*/

    //public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivity = 100.0f;
    public float minimumVert = -45.0f;
    public float maximumVert = 90.0f;
    private float _rotationX = 0;

    public Transform playerBody;


    void Start(){
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {   
        
        //In mouse X und Y werden ein Wert zwischne 1 u. -1 eins gespeichtert (1=recht,-1=links)
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        
        //mit .Clamp wird die bestimmt wie weit man sich vertikal bewegen kann 
        _rotationX -= mouseY;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

        transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        /*if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0,Input.GetAxis("Mouse X") * sensitivityHor,0);        
        }
        else if (axes == RotationAxes.MouseY)
        {
           _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
           _rotationX = Mathf.Clamp(_rotationX, minimumVert,maximumVert);

           float rotationY = transform.localEulerAngles.y;
                                                                                    Altes MouseLook Script, hat es nicht zugelassen das man beim öffnen des Menus nicht mehr herumschauen konnte.
           transform.localEulerAngles = new Vector3(_rotationX,rotationY,0);
        }
        else
        {
           _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
           _rotationX = Mathf.Clamp(_rotationX, minimumVert,maximumVert);

           float delta = Input.GetAxis("Mouse X") * sensitivityHor;
           float rotationY = transform.localEulerAngles.y + delta;

           transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }*/
    }
}
