using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongTilesLogic : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.Instance.isRedSphereTaken)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                player.transform.position = new Vector3(84.7f, 2.27f, -2.2f);
            }
        }
    }
}
