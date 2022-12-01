using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactLogic : MonoBehaviour
{
    //Declare Materials
    private Material[] getMaterial;
    private Material yellowLight;
    private Material purpleLight;
    private Material greenLight;
    private Material redLight;

    //Declare Materials State Vraiables
    private float red;
    private bool isRedRising = true;
    private float green;
    private bool isGreenRising = true;
    private float yellow;
    private bool isYellowRising = true;
    private float purple;
    private bool isPurplerising = true;

    void Start()
    {
        //Assign each material to a certain material variable.
        getMaterial = GetComponent<Renderer>().materials;
        yellowLight = getMaterial[4];
        purpleLight = getMaterial[5];
        greenLight = getMaterial[3];
        redLight = getMaterial[2];

        //Assign default values for the intensity level of each light
        red = 5.0f;
        yellow = 5.0f;
        purple = 5.0f;
        green = 5.0f;

     /*   for (int i = 0; i < 6; i++) {

            Debug.Log(getMaterial[i]);

        }

        */
          
    }

    void Update()
    {
        //Lights Logic
        YellowLight();
        PurpleLight();
        GreenLight();
        RedLight();
    }

    private void changeRedValue()
    {

        if (red < 5 || red > 50)
        {
            isRedRising = !isRedRising;
        }

        if (isRedRising)
        {
            red += 0.25f;
        }
        else
        {
            red -= 0.25f;
        }
    }

    private void RedLight()
    {

        if (GameManager.Instance.isRedSphereTaken)
        {
            changeRedValue();
            redLight.SetColor("_EmissiveColor", Color.red * red);
        }
    }

    private void GreenLight()
    {

        if (GameManager.Instance.isGreenSphereTaken)
        {
            changeGreenValue();
            greenLight.SetColor("_EmissiveColor", Color.green * green);
        }
    }

    private void changeGreenValue()
    {

        if (green < 5 || green > 15)
        {
            isGreenRising = !isGreenRising;
        }

        if (isGreenRising)
        {
            green += 0.1f;
        }
        else
        {
            green -= 0.1f;
        }
    }

    private void changePurpleValue()
    {

        if (purple < 5 || purple > 20)
        {
            isPurplerising = !isPurplerising;
        }

        if (isPurplerising)
        {
            purple += 0.1f;
        }
        else
        {
            purple -= 0.1f;
        }

    }

    private void PurpleLight()
    {

        if (GameManager.Instance.isPurpleSpheretaken)
        {
            changePurpleValue();
            purpleLight.SetColor("_EmissiveColor", Color.magenta * purple);
        }
    }

    private void changeYellowValue()
    {

        if (yellow < 5 || yellow > 15)
        {
            isYellowRising = !isYellowRising;
        }

        if (isYellowRising)
        {
            yellow += 0.1f;
        }
        else
        {
            yellow -= 0.1f;
        }
        
    }

    private void YellowLight() {

        if (GameManager.Instance.isYellowSphereTaken)
        {
            changeYellowValue();
            yellowLight.SetColor("_EmissiveColor", Color.yellow * yellow);
        }
    }
}
