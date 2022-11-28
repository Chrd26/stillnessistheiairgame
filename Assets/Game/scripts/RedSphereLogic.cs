using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSphereLogic : MonoBehaviour
{

    Material R_Material;
    float increaseItensity;
    bool increase;

    // Start is called before the first frame update
    void Start()
    {
        R_Material = GetComponent<Renderer>().material;

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

        if (increaseItensity < 0 || increaseItensity > 255)
        {
            increase = !increase;

        }

        R_Material.SetColor("_EmissiveColor", Color.red * increaseItensity);

    }

    // Update is called once per frame
    void Update()
    {
        changeEmission();
    }
}
