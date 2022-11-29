using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    //Declare Variables
    public float speed = 8f;
    public float jumpForce = 80;
    private float gravity = -30;
    public float mouseX;
    public float mouseY;
    private Vector3 velocity;
    public float rotationSpeed = 200.0f;
    private bool canJump;
    private bool isonGround;
    private bool isCrouching;
    private bool isRunning;
    private bool hasTeleportedAtGreenSphere = false;
    private bool enableControls = false;

    // Update is called once per frame
    void Update()
    {
        if (enableControls)
        {

            if (GameManager.Instance.isGreenSphereTaken && !hasTeleportedAtGreenSphere)
            {
                transform.position = new Vector3(-90.33f, 32.34f, -0.44f);
                hasTeleportedAtGreenSphere = true;
            }

            //Declare Variables.
            CharacterController controller = GetComponent<CharacterController>();
            Vector3 controllerVelocity = GetComponent<CharacterController>().velocity;

            //rotate the player when the mouse moves.
            mouseX = Mathf.Clamp(mouseX + Input.GetAxis("Mouse Y") * rotationSpeed * -1, -90f, 90f);
            mouseY = mouseY + Input.GetAxis("Mouse X") * rotationSpeed;
            Camera.main.transform.rotation = Quaternion.Euler(new Vector3(mouseX, mouseY, 0));

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
                    velocity.y += jumpForce;
                }

            }


            //Run Logic When the shift button is pressed then the player will gradually move faster.

            if (isRunning)
            {
                speed = Mathf.Clamp(speed + 15.0f * Time.deltaTime, 8, 20);
            }


            if (Input.GetButton("Run") && !isCrouching)
            {

                isRunning = true;

            }
            else if (Input.GetButtonUp("Run"))
            {
                isRunning = false;

            }


            //Crouch Logic When the left ctrl button is pressed then the player will gradually lower down and move slower and sneak.

            if (isCrouching)
            {

                speed = Mathf.Clamp(speed - 15.0f * Time.deltaTime, 3, 8);
                transform.localScale = new Vector3(1.0f, Mathf.Clamp(transform.localScale.y - 2.0f * Time.deltaTime, 0.9f, 1.8f), 1.0f);

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
                    transform.localScale = new Vector3(1.0f, Mathf.Clamp(transform.localScale.y + 2.0f * Time.deltaTime, 0.5f, 1.8f), 1.0f);
                }
            }


            //Gravity and add move velocity to the controller and sync physics to be able to teleport around.
            Physics.SyncTransforms();
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }      

    }

   public void DisableMouse()
    {
        //Hide the cursor and lock in place.
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }

    public void EnableControls()
    {
        enableControls = true;
    }

    
}
