using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactLogic : MonoBehaviour
{
    //Declare Materials
    private Material[] getMaterial;
    private Material yellowLight;
    private Material purpleLight;
    private float yellow;
    private bool isYellowRising = true;
    private float purple;
    private bool isPurplerising = true;

    void Start()
    {
        //Get the array of materials
        getMaterial = GetComponent<Renderer>().materials;
        yellowLight = getMaterial[4];
        purpleLight = getMaterial[5];
        yellow = 5.0f;
        purple = 5.0f;

        /*for (int i = 0; i < 6; i++) {

            Debug.Log(getMaterial[i]);

        }
        */
    }

    void Update()
    {
        //Lights Logic
        YellowLight();
        PurpleLight();
    }


    private void changePurpleValue()
    {

        if (purple < 5 || purple > 255)
        {
            isPurplerising = !isPurplerising;
        }

        if (isPurplerising)
        {
            purple += 1;
        }
        else
        {
            purple -= 1;
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

        if (yellow < 5 || yellow > 255)
        {
            isYellowRising = !isYellowRising;
        }

        if (isYellowRising)
        {
            yellow += 1;
        }
        else
        {
            yellow -= 1;
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
