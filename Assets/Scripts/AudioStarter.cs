using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStarter : MonoBehaviour
{
    private AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Play()
    {
        audio.PlayOneShot(audio.clip);
    }
}
