using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 5;
    private float gravity = -9.81f;
    bool canJump;
    bool isonGround;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
       
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        Vector3 controllerVelocity = GetComponent<CharacterController>().velocity;
        Vector3 mousePOS = Input.mousePosition;

        Debug.Log(mousePOS.x);
        Debug.Log(mousePOS.y);

        isonGround = controller.isGrounded;


        if (Input.GetButton("Vertical") && isonGround)
        {
            velocity.z = Input.GetAxis("Vertical") * speed;
        }else if (Input.GetButtonUp("Vertical"))
        {
            velocity.z = 0;
        }

        if (Input.GetButton("Horizontal") && isonGround)
        {
            velocity.x = Input.GetAxis("Horizontal") * speed;
           
        }
        else if (Input.GetButtonUp("Horizontal"))
        {
            velocity.x = 0;
        }



        if (Input.GetButtonDown("Jump"))
        {
            if (isonGround)
            {
                velocity.y = 0.0f;
            }

            if(canJump && isonGround)
            {
                velocity.y += Mathf.Sqrt(jumpForce * -1 * gravity);
                canJump = false;
            }

            if(controller.velocity.y == 0)
            {
                canJump = true;
            }
            else
            {
                canJump = false;
            }

        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
       

    }

    
}
