using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource mapSong;

    void Start()
    {
        mapSong = GetComponent<AudioSource>();
        mapSong.volume = 0.05f;
        mapSong.Play();
    }

    
    void Update()
    {
        
    }
}
