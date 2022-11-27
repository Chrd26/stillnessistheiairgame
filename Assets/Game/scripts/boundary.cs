using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundary : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector3(0.32f, 2.28f, -24.25f);
        }
    }
}
