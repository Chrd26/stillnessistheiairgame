using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary2 : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector3(-90.33f, 32.34f, -0.44f);
        }
    }
}
