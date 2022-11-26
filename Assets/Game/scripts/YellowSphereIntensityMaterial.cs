using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowSphereIntensityMaterial : MonoBehaviour
{

    Material Y_Material;
    float increaseItensity;
    bool increase;

    // Start is called before the first frame update
    void Start()
    {
        Y_Material = GetComponent<Renderer>().material;

    }

    void changeEmission()
    {

        if (increase)
        {
            increaseItensity += 0.5f;
        }
        else
        {
            increaseItensity -= 0.5f;
        }

	        if (increaseItensity > 300 || increaseItensity < -100)
        {
            increase = !increase;

        }

        Y_Material.SetColor("_EmissiveColor", new Color(increaseItensity, increaseItensity, 0, 255));

    }

    // Update is called once per frame
    void Update()
    {

        changeEmission();

    }

}
