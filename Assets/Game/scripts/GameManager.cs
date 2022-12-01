using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Create an instance of Game Manager to be available everywhere.

    public static GameManager Instance;

    //Chapter 1 Variables

    public bool isYellowSphereTaken = false, isRedSphereTaken = false, isPurpleSpheretaken = false, isGreenSphereTaken = false;

    public bool isPlatform1Moving = true, isPlatform2Moving = true, isPlatform3Moving = true, isPlatform4Moving = true, isPlatform5Moving = true, isPlatform6Moving = true;

    public bool hasGameStarted = false;
    public bool isPlayerTouchGroundSurface = false;

    public bool isLookingAtInteractable = false;
    public bool hasIntroPlayed = false;
    public int chapter = 1;
    public bool enableControls = false;

    //Check if the instance is null, if it is then add this script to the instance

    private void Awake()
    {
        if (Instance == null) {

            Instance = this;
	}
        DontDestroyOnLoad(this);
    }

    public void EnableGameplay()
    {
        hasGameStarted = true;
    }
}
