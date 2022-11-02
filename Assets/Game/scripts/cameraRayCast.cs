using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRayCast : MonoBehaviour
{
    RaycastHit hit;
    public GameObject rayCasterObject;
    bool isSelected;

    private void Update()
    {
        Debug.DrawLine(transform.position, new Vector3(0, 0, 2), Color.green);
    }

    private void FixedUpdate()
    {
     
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        LayerMask hitInteractiveObject = LayerMask.GetMask("Interactive Items");


        if (Physics.Raycast(transform.position, fwd, out hit, 2, hitInteractiveObject))
        {
            Debug.Log(hit.collider.gameObject.name);

            if (Input.GetButton("Use"))
            {
                rayCasterObject = hit.collider.gameObject;
                Destroy(rayCasterObject);
            }
           
        }


    }
}
