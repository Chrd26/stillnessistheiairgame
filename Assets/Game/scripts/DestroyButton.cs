using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyButton : MonoBehaviour
{
    public GameObject getButton;
    public GameObject getCursor;

    private void Update()
    {
        if (GameManager.Instance.hasGameStarted)
        {
            Disable();
        }
    }

    public void Disable()
    {
        getButton.SetActive(false);
        getCursor.SetActive(true);

    }
}
