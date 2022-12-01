using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundSurface : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.isPlayerTouchGroundSurface = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.isPlayerTouchGroundSurface = false;
        }
    }
}
