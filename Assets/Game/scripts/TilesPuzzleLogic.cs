using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesPuzzleLogic : MonoBehaviour
{
    private Material[] getMaterials;
    private Material path1;
    private Material path2;
    private Material path3;
    private Material path4;
    private Material path5;
    private Material path6;
    private Material path7;
    private Material path8;
    private Material path9;
    private Material path10;
    private Material path11;
    private Material path12;
    private Material path13;
    private Material path14;
    private Material path15;
    private Material path16;
    private Material path17;
    private Material wrongTiles;
    private float wrongTilesEmission;
    private bool isWrongEmissionIncreasing;

    // Start is called before the first frame update
    void Start()
    {
        getMaterials = GetComponent<Renderer>().materials;
        wrongTiles = getMaterials[1];
        wrongTilesEmission = 50;
        isWrongEmissionIncreasing = true;

        for (int i = 0; i < 19; i++)
        {
            Debug.Log(getMaterials[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        wrongTilesEmissionControl();
    }

    private void wrongTilesEmissionControl()
    {
        if (wrongTilesEmission < -20 || wrongTilesEmission > 100)
        {
            isWrongEmissionIncreasing = !isWrongEmissionIncreasing;
        }

        if (isWrongEmissionIncreasing)
        {
            wrongTilesEmission += 0.5f;
        }
        else
        {
            wrongTilesEmission -= 0.5f;
        }

        wrongTiles.SetColor("_EmissiveColor", Color.red * wrongTilesEmission);
    }
}
