using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    //Declare Variables

    //Movement Variables
    public float speed = 8f, rotationSpeed = 200.0f, jumpForce = 80, gravity = -30, mouseX, mouseY, waitTime = 0, waitTime2 = 0, waitTime3 = 0, flyingTime = 0;
    private Vector3 velocity;
    private bool canJump, isonGround, isCrouching, isRunning, hasTeleportedAtGreenSphere = false, hasPlayed = false;
    CharacterController controller;
    Vector3 controllerVelocity;

    //Audio variables
    public AudioSource walkDefaultSource;
    public AudioSource walkGroundSource;

    public AudioSource runDefaultSource;
    public AudioSource runGroundSource;

    public AudioSource jumpDefaultSource;
    public AudioSource jumpGroundSource;

    public AudioSource landDefaultSource;
    public AudioSource landGroundSource;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        controllerVelocity = GetComponent<CharacterController>().velocity;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(waitTime);

        if (GameManager.Instance.enableControls)
        {
            if (GameManager.Instance.isGreenSphereTaken && !hasTeleportedAtGreenSphere)
            {
                transform.position = new Vector3(-90.33f, 32.34f, -0.44f);
                hasTeleportedAtGreenSphere = true;
            }

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

            EnableMovementSounds();

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
        GameManager.Instance.enableControls = true;
    }

    //Movement Sounds Logic

    private void EnableMovementSounds()
    {
        if (Input.GetButton("Horizontal") && isonGround || Input.GetButton("Vertical") && isonGround)
        {
            if (!isRunning && !isCrouching)
            {
                WalkSound();
            }
            else if (isRunning && !isCrouching)
            {
                RunSound();
            }
            else if (!isRunning && isCrouching)
            {
                CrouchSound();
            }

            if (Input.GetButtonDown("Jump"))
            {
                JumpSound();
                hasPlayed = false;
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            JumpSound();
            hasPlayed = false;
        }

        if (!isonGround)
        {
            hasPlayed = false;
            flyingTime += 1 * Time.deltaTime;
        }
        else if (!hasPlayed)
        {
            if (flyingTime >= 0.3f)
            {
                LandSound();
            }
            else
            {
                flyingTime = 0;
            }
        }

        if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            waitTime = 0;
            waitTime2 = 0;
            waitTime3 = 0;
        }
    }

    private void WalkSound()
    { 
        if (GameManager.Instance.isPlayerTouchGroundSurface)
        {
            if (waitTime > 0.5)
            {
                if (!walkGroundSource.isPlaying)
                {
                    walkGroundSource.Play();
                    runDefaultSource.volume = 1;
                }
                waitTime = 0;
            }
            else
            {
                waitTime += 1 * Time.deltaTime;
            }
        }
        else
        {
            if (waitTime > 0.5)
            {
                if (!walkDefaultSource.isPlaying)
                {
                    walkDefaultSource.Play();
                    runDefaultSource.volume = 1;
                }
                waitTime = 0;
            }
            else
            {
                waitTime += 1 * Time.deltaTime;
            }

        }
    }


    private void RunSound()
    {
        if (GameManager.Instance.isPlayerTouchGroundSurface)
        {
            if (waitTime2 > 0.3)
            {
                if (!runGroundSource.isPlaying)
                {
                    runGroundSource.Play();
                }
                waitTime2 = 0;
            }
            else
            {
                waitTime2 += 1 * Time.deltaTime;
            }
        }
        else
        {
            if (waitTime2 > 0.3)
            {
                if (!runDefaultSource.isPlaying)
                {
                    runDefaultSource.Play();
                }
                waitTime2 = 0;
            }
            else
            {
                waitTime2 += 1 * Time.deltaTime;
            }

        }
    }

    private void CrouchSound()
    {
        if (GameManager.Instance.isPlayerTouchGroundSurface)
        {
            if (waitTime3 > 0.8)
            {
                walkGroundSource.Play();
                walkDefaultSource.volume = 0.2f;
                waitTime3 = 0;
            }
            else
            {
                waitTime3 += 1 * Time.deltaTime;
            }
        }
        else
        {
            if (waitTime3 > 0.8)
            {
                walkDefaultSource.Play();
                walkDefaultSource.volume = 0.2f;
                waitTime3 = 0;
            }
            else
            {
                waitTime3 += 1 * Time.deltaTime;
            }

        }
    }

    private void JumpSound()
    {
        if (GameManager.Instance.isPlayerTouchGroundSurface)
        {
            jumpGroundSource.Play();
        }
        else
        {
            jumpDefaultSource.Play();
        }
    }

    private void LandSound()
    {
        if (GameManager.Instance.isPlayerTouchGroundSurface)
        {
            landGroundSource.Play();
            hasPlayed = true;
            flyingTime = 0;
        }
        else
        {
            landDefaultSource.Play();
            hasPlayed = true;
            flyingTime = 0;
        }
    }
}
