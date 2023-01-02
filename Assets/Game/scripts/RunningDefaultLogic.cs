using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningDefaultLogic : MonoBehaviour
{
    public int randomClip;
    public float timeWait;
    public AudioClip[] runDefaultClips;
    private AudioClip runDefaultclip;
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
        if (!audioSource.isPlaying)
        {
            randomClip = Random.Range(0, 5);
            runDefaultclip = runDefaultClips[randomClip];
            audioSource.clip = runDefaultclip;
            audioSource.pitch = Random.Range(1.0f, 1.05f);
        }
    }
}

