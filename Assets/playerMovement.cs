using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    //Declare Variables
    public float speed = 8f;
    public float jumpForce = 0.5f;
    private float gravity = -70f;
    public float mouseX;
    public float mouseY;
    private Vector3 velocity;
    public float rotationSpeed = 100.0f;
    bool canJump;
    bool isonGround;
    bool isCrouching;
    bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;    
    }

    // Update is called once per frame
    void Update()
    {
        //Declare Variables.
        CharacterController controller = GetComponent<CharacterController>();
        Vector3 controllerVelocity = GetComponent<CharacterController>().velocity;

        //rotate the player when the mouse moves.
        mouseX = Mathf.Clamp(mouseX + Input.GetAxis("Mouse Y") * rotationSpeed * -1, -90f, 90f);
        mouseY = mouseY + Input.GetAxis("Mouse X") * rotationSpeed;
       
        transform.rotation = Quaternion.Euler(new Vector3(mouseX, mouseY, 0));
      
        //Check if the player is on the ground.
        isonGround = controller.isGrounded;

        // The player moves around based on the camera position and can jump if the player touches the ground.

        if (controller.isGrounded)
        {

            velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
            velocity = Camera.main.transform.TransformDirection(velocity);
            velocity.y = 0;

            if (Input.GetButton("Jump"))
            {
                velocity.y += Mathf.Sqrt(jumpForce * -1 * gravity);
            }

        }


        //Run Logic When the shift button is pressed then the player will gradually move faster.

        if (isRunning && !isCrouching)
        {
            speed = Mathf.Clamp(speed + 15.0f * Time.deltaTime, 8, 20);
        }
  

        if (Input.GetButton("Run"))
        {
           
            isRunning = true;

        }else if (Input.GetButtonUp("Run"))
        {
            isRunning = false;
            
        }


        //Crouch Logic When the left ctrl button is pressed then the player will gradually lower down and move slower and sneak.

        if (isCrouching)
        {
            
            speed = Mathf.Clamp(speed - 15.0f * Time.deltaTime, 3, 8);
            transform.localScale = new Vector3(1.0f, Mathf.Clamp(transform.localScale.y - 2.0f * Time.deltaTime, 0.5f, 1f), 1.0f); 

        }


        if (Input.GetButton("Crouch"))
        {
            isCrouching = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {

            isCrouching = false;
            
        }

        //Return to the original speed and scale value.

        if (!isCrouching && !isRunning)
        {
            if (speed > 8)
            {
                speed = Mathf.Clamp(speed - 15.0f * Time.deltaTime, 8, 20);
            }
            else
            {
                speed = Mathf.Clamp(speed + 15.0f * Time.deltaTime, 3, 8);
                transform.localScale = new Vector3(1.0f, Mathf.Clamp(transform.localScale.y + 2.0f * Time.deltaTime, 0.5f, 1f), 1.0f);
            }
        }

      
        //Gravity and add move velocity to the controller.

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        
       

    }

    
}
