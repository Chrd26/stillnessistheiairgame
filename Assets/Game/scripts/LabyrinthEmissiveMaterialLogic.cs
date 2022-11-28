using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthEmissiveMaterialLogic : MonoBehaviour
{
    private Material[] getMaterials;
    private Material getPurpleMaterial;
    private float intensity;
    private bool isIncreasing = true;
    // Start is called before the first frame update
    void Start()
    {
        getMaterials = GetComponent<Renderer>().materials;
        getPurpleMaterial = getMaterials[2];

       /* for (int i = 0; i < 6; i++)
        {
            Debug.Log(getMaterials[i]);
        }
       */
    }

    // Update is called once per frame
    void Update()
    {
        Increase_Decrease(); 
    }


    private void Increase_Decrease()
    {
        if (intensity < 0 || intensity > 150)
        {
            isIncreasing = !isIncreasing;
        }

        if (isIncreasing)
        {
            intensity += 0.5f;
        }
        else
        {
            intensity -= 0.5f;
        }

        getPurpleMaterial.SetColor("_EmissiveColor", Color.magenta * intensity);

    }
}
