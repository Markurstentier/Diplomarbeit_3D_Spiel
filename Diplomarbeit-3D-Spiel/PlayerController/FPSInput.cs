using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour
{

    public float speed = 6.0f;
    public float sprint_speed = 40;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    Vector3 movement;
    private CharacterController _charController;

    //Mehrere Variablen zur Kontrolle ob der Spieler sich am Boden befindet
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;


    void Start() {
        /*
        GetComponent holt sich einen gewählten Component des Objekts andem des angemacht ist.
        Mit _charController können wir jetzt auf Funktionen des "CharakterController" Components zugreifen
        */
        _charController = GetComponent<CharacterController>();

    }
    // Update is called once per frame
    void Update()
    {   
        /*
        Mit CheckSphere wird eine Sphere unter dem Spieler erstellt die checkt ob der sich am Boden befindet.
        Diese funktioniert mit indem es eine Kugel unter dem Spieler erschafft der check ob er mit dem Boden
        kollidiert    
        */
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && movement.y < 0){
            movement.y = -2f;
        }

        /*
        Mit Input.GetAxis können wir Inputs über "WASD" oder den Pfeiltasten einlesen.
        In deltaX und deltaY werden dann die Werte der virtuellen Achsen gespeichert.
        */
        float deltaX = Input.GetAxis("Horizontal"); //"A" u. "D"
        float deltaZ = Input.GetAxis("Vertical"); //"W" u. "S"

        Vector3 move = transform.right * deltaX + transform.forward * deltaZ;

        if(Input.GetButton("Sprint") && Input.GetKey(KeyCode.LeftShift)){
            _charController.Move(move * sprint_speed * Time.deltaTime);
            Debug.Log("You sprinting");
        }
        else {
            _charController.Move(move * speed * Time.deltaTime);
            Debug.Log("You not sprinting");
        }

        if (Input.GetButtonDown("Jump") && isGrounded) {
            movement.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        movement.y += gravity * Time.deltaTime;
        _charController.Move(movement * Time.deltaTime);


        /*if(Input.GetButtonDown("Sprint")){
            movement.x = movement.x + sprint_speed;

        } else if (Input.GetButtonUp("Sprint")) {
            movement.x = movement.x - sprint_speed;

        } else {
            movement.x = speed;
            
        }*/
        }

 
    }
