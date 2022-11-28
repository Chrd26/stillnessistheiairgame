using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Create an instance of Game Manager to be available everywhere.

    public static GameManager Instance;

    //Chapter 1 Variables

    public bool isYellowSphereTaken = false;
    public bool isRedSphereTaken = false;
    public bool isPurpleSpheretaken = false;
    public bool isGreenSphereTaken = false;

    public bool isPlatform1Moving = true;
    public bool isPlatform2Moving = true;
    public bool isPlatform3Moving = true;
    public bool isPlatform4Moving = true;
    public bool isPlatform5Moving = true;
    public bool isPlatform6Moving = true;

    public bool isLookingAtInteractable = false;

    //Check if the instance is null, if it is then add this script to the instance

    private void Awake()
    {
        if (Instance == null) {

            Instance = this;
	}
    }
}
