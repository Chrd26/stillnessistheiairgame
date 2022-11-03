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
    }

    private void FixedUpdate()
    {
        
        //Get the the forward position of the camera and the Interactive Items layer, so
        //the raycast only counts hits with that certain layer.
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        LayerMask hitInteractiveObject = LayerMask.GetMask("Interactive Items");

        //Check if the raycst hits an object that nelongs to the Interactibe Items Layer
        // Raycast declaration and arguments
        // Physics.Raycast(origin, ray direction, out Racasthit, max distance, layer mask)
        if (Physics.Raycast(transform.position, fwd, out hit, 2, hitInteractiveObject))
        {
            Debug.Log(hit.collider.gameObject.name);

            if (Input.GetButton("Use"))
            {
                //Get the game object that the racast hits and destroy it.
                rayCasterObject = hit.collider.gameObject;
                Destroy(rayCasterObject);
            }
           
        }


    }
}
