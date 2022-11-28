using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRayCast : MonoBehaviour
{

    //Deflare Viarables
    RaycastHit hit;
    public GameObject rayCasterObject;
    bool isSelected;

    private void Update()
    {
        //Draw a line to see the placement of the raycast.
        Debug.DrawLine(transform.position, new Vector3(0, 0, 2), Color.green);

        //Get the the forward position of the camera and the Interactive Items layer, so
        //the raycast only counts hits with that certain layer.
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        LayerMask hitInteractiveObject = LayerMask.GetMask("Interactive Items");

        //Check if the raycst hits an object that nelongs to the Interactible Items Layer
        // Raycast declaration and arguments
        // Physics.Raycast(origin, ray direction, out Racasthit, max distance, layer mask)
        if (Physics.Raycast(transform.position, fwd, out hit, 5, hitInteractiveObject))
        {
            if (Input.GetButtonDown("Use"))
            {

                if (hit.collider.gameObject.CompareTag("RedSphere"))
                {

                    GameManager.Instance.isRedSphereTaken = true;

                    //Get the game object that the raycast hits and destroy it.
                    rayCasterObject = hit.collider.gameObject;
                    Destroy(rayCasterObject);
                }

                if (hit.collider.gameObject.CompareTag("GreenSphere"))
                {

                    GameManager.Instance.isGreenSphereTaken = true;

                    //Get the game object that the raycast hits and destroy it.
                    rayCasterObject = hit.collider.gameObject;
                    Destroy(rayCasterObject);
                }

                if (hit.collider.gameObject.CompareTag("YellowSphere"))
                {

                    GameManager.Instance.isYellowSphereTaken = true;

                    //Get the game object that the raycast hits and destroy it.
                    rayCasterObject = hit.collider.gameObject;
                    Destroy(rayCasterObject);
                }

                if (hit.collider.gameObject.CompareTag("PurpleSphere"))
                {

                    GameManager.Instance.isPurpleSpheretaken = true;

                    //Get the game object that the raycast hits and destroy it.
                    rayCasterObject = hit.collider.gameObject;
                    Destroy(rayCasterObject);
                }

                if (hit.collider.gameObject.CompareTag("StopButton"))
                {

                    if (GameManager.Instance.isPlatform1Moving)
                    {

                        GameManager.Instance.isPlatform1Moving = false;

                    }
                    else if (!GameManager.Instance.isPlatform1Moving && GameManager.Instance.isPlatform2Moving)
                    {

                        GameManager.Instance.isPlatform2Moving = false;

                    }
                    else if (!GameManager.Instance.isPlatform2Moving && GameManager.Instance.isPlatform3Moving)
                    {

                        GameManager.Instance.isPlatform3Moving = false;

                    }
                    else if (!GameManager.Instance.isPlatform3Moving && GameManager.Instance.isPlatform4Moving)
                    {

                        GameManager.Instance.isPlatform4Moving = false;

                    }
                    else if (!GameManager.Instance.isPlatform4Moving && GameManager.Instance.isPlatform5Moving)
                    {

                        GameManager.Instance.isPlatform5Moving = false;

                    }
                    else if (!GameManager.Instance.isPlatform5Moving && GameManager.Instance.isPlatform6Moving)
                    {

                        GameManager.Instance.isPlatform6Moving = false;

                    }
                }


                if (hit.collider.gameObject.CompareTag("ResetButton"))
                {

                    GameManager.Instance.isPlatform1Moving = true;
                    GameManager.Instance.isPlatform2Moving = true;
                    GameManager.Instance.isPlatform3Moving = true;
                    GameManager.Instance.isPlatform4Moving = true;
                    GameManager.Instance.isPlatform5Moving = true;
                    GameManager.Instance.isPlatform6Moving = true;

                }

            }

        }
    }

}
