using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class WeatherControl : MonoBehaviour
{
    //Variables get the volume that contains the fog override
    public Volume volume;
    private Fog getFog;
    private float setFogAtt;
    private bool fogIncreasing;
 

    // Start is called before the first frame update
    void Awake()
    {
        //Set Default Values

        setFogAtt = 150.0f;
        fogIncreasing = true;
    }

    // Update is called once per frame
    void Update()
    {
        float grabFogValue = FogAttenuationValue();
        FogAttenuation(grabFogValue);
             
    }

    void FogAttenuation(float getValue) {

        //Get the fog component from the public volume, set the value of the flog
        //to the value that is recieved in the argument.

        if (!volume.profile.TryGet<Fog>(out var getFog))
        {
            getFog = volume.profile.Add<Fog>(false);
        }
        
        getFog.meanFreePath.value = getValue;

    }

    public float FogAttenuationValue() {

        //Change the value of the attenuation dynamically and return it.

        if (setFogAtt > 350 || setFogAtt < 50)
        {
            fogIncreasing = !fogIncreasing;
        }

        if (fogIncreasing)
        {

            setFogAtt += 0.1f * Time.deltaTime;

        }
        else
        {

            setFogAtt -= 0.1f * Time.deltaTime;

        }

        return setFogAtt;

    }
}
