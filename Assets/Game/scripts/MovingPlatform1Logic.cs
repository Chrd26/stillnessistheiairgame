using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform1Logic : MonoBehaviour
{
    bool playAnim = false;
    private Animation getAnimation;
    private Material platfromMat;
    bool isPlayerColliding = false;
    float red = 0;
    float  blue = 0;
    float  green = 0;

    private void Awake()
    {
        getAnimation = GetComponent<Animation>();
        platfromMat = GetComponent<Renderer>().material;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player")) {

            isPlayerColliding = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Touch");

        if (collision.gameObject.CompareTag("Player"))
        {

            isPlayerColliding = false;

        }
    }

    void Update()
    {
        if (!GameManager.Instance.isPlatform1Moving){

            getAnimation.Stop();
            playAnim = false;

        }else if (GameManager.Instance.isPlatform1Moving && !playAnim) {

            getAnimation.Play();
            playAnim = true;
	    }

        if (isPlayerColliding) {

            platfromMat.SetColor("_EmissiveColor", new Color(red = Mathf.Clamp(red + 1, 0, 255), blue = Mathf.Clamp(blue + 1, 0, 255), green = Mathf.Clamp(green + 1, 0, 255), 255));

        }else {

            platfromMat.SetColor("_EmissiveColor", new Color(red = Mathf.Clamp(red - 1, 1, 255), blue = Mathf.Clamp(blue - 1, 1, 255), green = Mathf.Clamp(green - 1, 1, 255), 255));

        }
       
    }
}
