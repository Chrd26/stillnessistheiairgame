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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {

            isPlayerColliding = true;

	    }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {

            isPlayerColliding = false;
	
	    }
    }

    void Update()
    {

        AnimationManager();
        PlatformGlow();

    }

    private void AnimationManager() {

        if (!GameManager.Instance.isPlatform1Moving)
        {

            getAnimation.Stop();
            playAnim = false;

        }
        else if (GameManager.Instance.isPlatform1Moving && !playAnim)
        {

            getAnimation.Play();
            playAnim = true;
        }

    }


    private void PlatformGlow() {

        if (isPlayerColliding)
        {

            platfromMat.SetColor("_EmissiveColor", new Color(red = Mathf.Clamp(red = red += 1, 0, 5), blue = Mathf.Clamp(blue += 5, 0, 5), green = Mathf.Clamp(green += 5, 0, 5), 255));

        }
        else
        {

            platfromMat.SetColor("_EmissiveColor", new Color(red = Mathf.Clamp(red -= 5, 1, 5), blue = Mathf.Clamp(blue -= 5, 1, 5), green = Mathf.Clamp(green -= 5, 1, 5), 255));

        }

    }
}
