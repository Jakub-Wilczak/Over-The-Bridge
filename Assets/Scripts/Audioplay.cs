using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audioplay : MonoBehaviour
{
    private AudioSource aud;
    void Start()
    {
        aud = GetComponent<AudioSource>();



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play_Sound()
    {
        aud.Play();
    }
}
