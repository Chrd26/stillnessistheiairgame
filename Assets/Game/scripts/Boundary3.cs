using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary3 : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector3(21.1f, 2.27f, -2.2f);
        }
    }
}
