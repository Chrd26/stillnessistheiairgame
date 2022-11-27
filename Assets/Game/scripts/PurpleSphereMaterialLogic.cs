using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleSphereMaterialLogic : MonoBehaviour
{
    private Material P_Material;
    private float IncreaseIntensity;
    bool isIncreasing = true;

    // Start is called before the first frame update
    void Start()
    {
        P_Material = GetComponent<Renderer>().material;
        IncreaseIntensity = 25.0f;
    }

    // Update is called once per frame
    void Update()
    {
        changePMaterialDynamically();   
    }


    void changePMaterialDynamically()
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

        P_Material.SetColor("_EmissiveColor", new Color(IncreaseIntensity, 0, IncreaseIntensity, 255));


    }
}
