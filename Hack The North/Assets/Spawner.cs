using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public AudioSource audioSource;
    public float offset = 0;
    public GameObject[] notes;
    public float[] times;
    public Vector3[] positions;

    private float songPos = 0;
    private float dspSongTime = 0;
    private float beforeTime = 1.35f;
    private int ind = 0;

    public void Start()
    {
        audioSource.Play();
        dspSongTime = (float)AudioSettings.dspTime;
    }

    public void Update()
    {
        if (ind >= notes.Length) return;
        songPos += ((float)(AudioSettings.dspTime - dspSongTime) - offset) * audioSource.pitch;
        dspSongTime = (float)AudioSettings.dspTime;
        if(songPos >= times[ind] - beforeTime)
        {
            Instantiate(notes[ind], new Vector3(Random.Range(-0.4f, 0.4f), Random.Range(-0.4f, 0.4f), 0), transform.rotation);
            ind++;
        }
    }
}
