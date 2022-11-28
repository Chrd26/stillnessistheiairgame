using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSphereLightUpLogic : MonoBehaviour
{
    private Material G_Material;
    private float IncreaseIntensity;
    bool isIncreasing = true;

    // Start is called before the first frame update
    void Start()
    {
        G_Material = GetComponent<Renderer>().material;
        IncreaseIntensity = 25.0f;
    }

    // Update is called once per frame
    void Update()
    {
        changePGaterialDynamically();
    }


    void changePGaterialDynamically()
    {

        if (IncreaseIntensity < 0 || IncreaseIntensity > 255)
        {

            isIncreasing = !isIncreasing;

        }

        if (isIncreasing)
        {
            IncreaseIntensity += 0.5f;
        }
        else
        {
            IncreaseIntensity += -0.5f;
        }

        G_Material.SetColor("_EmissiveColor", Color.green * IncreaseIntensity);
    }
}
