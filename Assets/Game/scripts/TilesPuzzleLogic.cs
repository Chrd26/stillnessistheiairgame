using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesPuzzleLogic : MonoBehaviour
{
    //Define Materials
    private Material[] getMaterials;
    private Material path1, path2, path3, path4, path5, path6, path7, path8;

    //Declare Animation Variable
    private int path1Counts, path2Counts, path3Counts, path4Counts, path5Counts, path6Counts, path7Counts, path8Counts;
    private float path1Intensity, waitingTime1, path2Intensity, waitingTime2, path3Intensity, waitingTime3, waitingTime4, path4Intensity, waitingTime5, path5Intensity, waitingTime6, path6Intensity, waitingTime7, path7Intensity, waitingTime8, path8Intensity;
    private bool isPath1EmissionIncreasing = true, isPath2EmissionIncreasing = true, isPath3EmissionIncreasing = true, isPath4EmissionIncreasing = true, isPath5EmissionIncreasing = true, isPath6EmissionIncreasing = true, isPath7EmissionIncreasing = true, isPath8EmissionIncreasing = true;

    // Start is called before the first frame update
    void Start()
    {
        //Assignment operations
        getMaterials = GetComponent<Renderer>().materials;
        path1 = getMaterials[8];
        path2 = getMaterials[7];
        path3 = getMaterials[6];
        path4 = getMaterials[5];
        path5 = getMaterials[4];
        path6 = getMaterials[3];
        path7 = getMaterials[2];
        path8 = getMaterials[1];

        path1Intensity = 50.0f;
        path1Counts = 0;

        path2Intensity = 50.0f;
        path2Counts = 0;

        path3Intensity = 50.0f;
        path3Counts = 0;

        path4Intensity = 50.0f;
        path4Counts = 0;

        path5Intensity = 50.0f;
        path5Counts = 0;

        path6Intensity = 50.0f;
        path6Counts = 0;

        path7Intensity = 50.0f;
        path7Counts = 0;

        path8Intensity = 50.0f;
        path8Counts = 0;

        /*  for (int i = 0; i < 8; i++)
           {
               Debug.Log(getMaterials[i]);
           }
        */
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameManager.Instance.isRedSphereTaken)
        {
            FirstPath();
            SecondPath();
            ThirdPath();
            FourthPath();
            FifthPath();
            SixthPath();
            SeventhPath();
            EighthPath();
        }
        else
        {
            Deactivate();
        }
    }

    private void FirstPath()
    {
        if (path1Counts < 8)
        {
            waitingTime1 = 1;

            if (path1Intensity > 150 || path1Intensity < -100)
            {
                {
                    isPath1EmissionIncreasing = !isPath1EmissionIncreasing;
                    path1Counts++;
                }
            }


            if (isPath1EmissionIncreasing)
            {
                path1Intensity += 5f;
            }
            else
            {
                path1Intensity -= 5f;
            }

            path1.SetColor("_EmissiveColor", Color.red * path1Intensity);

        }else
        {
            if (waitingTime1 > 10 )
            {
                path1Counts = 0;
            }
            else
            {
                waitingTime1 += waitingTime1 * Time.deltaTime;
            }
        }
    }

    private void SecondPath()
    {
        if (path2Counts < 6)
        {
            waitingTime2 = 1;

            if (path2Intensity > 150 || path2Intensity < -100)
            {
                {
                    isPath2EmissionIncreasing = !isPath2EmissionIncreasing;
                    path2Counts++;
                }
            }


            if (isPath2EmissionIncreasing)
            {
                path2Intensity += 5f;
            }
            else
            {
                path2Intensity -= 5f;
            }

            path2.SetColor("_EmissiveColor", Color.red * path2Intensity);
        }
        else
        {
            if (waitingTime2 > 10)
            {
                path2Counts = 0;
            }
            else
            {
                waitingTime2 += waitingTime2 * Time.deltaTime;
            }
        }
    }

    private void ThirdPath()
    {
        if (path3Counts < 8)
        {
            waitingTime3 = 1;

            if (path3Intensity > 150 || path3Intensity < -100)
            {
                {
                    isPath3EmissionIncreasing = !isPath3EmissionIncreasing;
                    path3Counts++;
                }
            }


            if (isPath3EmissionIncreasing)
            {
                path3Intensity += 5f;
            }
            else
            {
                path3Intensity -= 5f;
            }

            path3.SetColor("_EmissiveColor", Color.red * path3Intensity);
        }
        else
        {
            if (waitingTime3 > 10)
            {
                path3Counts = 0;
            }
            else
            {
                waitingTime3 += waitingTime3 * Time.deltaTime;
            }
        }
    }

    private void FourthPath()
    {
        if (path4Counts < 10)
        {
            waitingTime4 = 1;

            if (path4Intensity > 150 || path4Intensity < -100)
            {
                {
                    isPath4EmissionIncreasing = !isPath4EmissionIncreasing;
                    path4Counts++;
                }
            }


            if (isPath4EmissionIncreasing)
            {
                path4Intensity += 5f;
            }
            else
            {
                path4Intensity -= 5f;
            }

            path4.SetColor("_EmissiveColor", Color.red * path4Intensity);
        }
        else
        {
            if (waitingTime4 > 10)
            {
                path4Counts = 0;
            }
            else
            {
                waitingTime4 += waitingTime4 * Time.deltaTime;
            }
        }
    }

    private void FifthPath()
    {
        if (path5Counts < 12)
        {
            waitingTime5 = 1;

            if (path5Intensity > 150 || path5Intensity < -100)
            {
                {
                    isPath5EmissionIncreasing = !isPath5EmissionIncreasing;
                    path5Counts++;
                }
            }


            if (isPath5EmissionIncreasing)
            {
                path5Intensity += 5f;
            }
            else
            {
                path5Intensity -= 5f;
            }

            path5.SetColor("_EmissiveColor", Color.red * path5Intensity);
        }
        else
        {
            if (waitingTime5 > 10)
            {
                path5Counts = 0;
            }
            else
            {
                waitingTime5 += waitingTime5 * Time.deltaTime;
            }
        }
    }

    private void SixthPath()
    {
        if (path6Counts < 12)
        {
            waitingTime6 = 1;

            if (path6Intensity > 150 || path6Intensity < -100)
            {
                {
                    isPath6EmissionIncreasing = !isPath6EmissionIncreasing;
                    path6Counts++;
                }
            }


            if (isPath6EmissionIncreasing)
            {
                path6Intensity += 5f;
            }
            else
            {
                path6Intensity -= 5f;
            }

            path6.SetColor("_EmissiveColor", Color.red * path6Intensity);
        }
        else
        {
            if (waitingTime6 > 10)
            {
                path6Counts = 0;
            }
            else
            {
                waitingTime6 += waitingTime6 * Time.deltaTime;
            }
        }
    }

    private void SeventhPath()
    {
        if (path7Counts < 10)
        {
            waitingTime7 = 1;

            if (path7Intensity > 150 || path7Intensity < -100)
            {
                {
                    isPath7EmissionIncreasing = !isPath7EmissionIncreasing;
                    path7Counts++;
                }
            }


            if (isPath7EmissionIncreasing)
            {
                path7Intensity += 5f;
            }
            else
            {
                path7Intensity -= 5f;
            }

            path7.SetColor("_EmissiveColor", Color.red * path7Intensity);
        }
        else
        {
            if (waitingTime7 > 10)
            {
                path7Counts = 0;
            }
            else
            {
                waitingTime7 += waitingTime7 * Time.deltaTime;
            }
        }
    }

    private void EighthPath()
    {
        if (path8Counts < 10)
        {
            waitingTime8 = 1;

            if (path8Intensity > 150 || path8Intensity < -100)
            {
                {
                    isPath8EmissionIncreasing = !isPath8EmissionIncreasing;
                    path8Counts++;
                }
            }


            if (isPath8EmissionIncreasing)
            {
                path8Intensity += 5f;
            }
            else
            {
                path8Intensity -= 5f;
            }

            path8.SetColor("_EmissiveColor", Color.red * path8Intensity);
        }
        else
        {
            if (waitingTime8 > 10)
            {
                path8Counts = 0;
            }
            else
            {
                waitingTime8 += waitingTime8 * Time.deltaTime;
            }
        }
    }

    private void Deactivate()
    {
        path1.SetColor("_EmissiveColor", Color.red * 0);
        path2.SetColor("_EmissiveColor", Color.red * 0);
        path3.SetColor("_EmissiveColor", Color.red * 0);
        path4.SetColor("_EmissiveColor", Color.red * 0);
        path5.SetColor("_EmissiveColor", Color.red * 0);
        path6.SetColor("_EmissiveColor", Color.red * 0);
        path7.SetColor("_EmissiveColor", Color.red * 0);
        path8.SetColor("_EmissiveColor", Color.red * 0);
    }

}
