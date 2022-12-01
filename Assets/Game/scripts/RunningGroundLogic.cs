using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningGroundLogic : MonoBehaviour
{
    public int randomClip;
    public float timeWait;
    public AudioClip[] runningGroundClips;
    private AudioClip runningGroundclip;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timeWait = 1;
    }

    private void Update()
    {
        if (timeWait > 1.5f)
        {
            EnumarateAudioClips();
            timeWait = 1;
        }
        else
        {
            timeWait += 0.1f;
        }

    }

    private void EnumarateAudioClips()
    {
        randomClip = Random.Range(0, 5);
        runningGroundclip = runningGroundClips[randomClip];
        audioSource.clip = runningGroundclip;
        audioSource.pitch = Random.Range(1.0f, 1.05f);
    }
}
