using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    //Define Music Tracks
    private AudioSource getSource;
    public AudioClip introMusic;
    public AudioMixerGroup mixerIntro;
    //private int trackList;

    public float length;

    private void Start()
    {
        getSource = GetComponent<AudioSource>();
        getSource.outputAudioMixerGroup = mixerIntro;
        getSource.clip = introMusic;

        if (!GameManager.Instance.hasIntroPlayed){
            getSource.Play();
        }    
    }

    private void Update()
    {
        if (!getSource.isPlaying)
        {
            GameManager.Instance.hasIntroPlayed = true;
        }
    }

/*
    //Reference for creating a tracklist of audiotracks

    private void PlayTackList()
    {

        if (!getSource.isPlaying)
        {
            if (trackList == 1)
            {
                Debug.Log("Play Second Track");
                getSource.Play();
                trackList++;
            }
            else if (trackList == 2)
            {
                Debug.Log("Play Third Track");
                getSource.Play();
                trackList++;
            }
        }
    }

    */

}
