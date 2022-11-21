using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmKeeper : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public SpriteRenderer renderer;

    public int bpm;
    public float firstBeatStartTime;
    public float precisionOffset;

    private float secondsPerBeat;

    private int currentBeat = 1;

    private float lastBeatTime = 0f;
    
    

    // Start is called before the first frame update
    void Start()
    {
        source.clip = clip;
        source.Play();

        secondsPerBeat = 60f / bpm;
    }

    private void FixedUpdate()
    {
        if (source.time >= secondsPerBeat * currentBeat + firstBeatStartTime)
        {
            currentBeat += 1;
            lastBeatTime = source.time;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if ((source.time - lastBeatTime) <= precisionOffset)
            {
                renderer.enabled = !renderer.enabled; 
            }
        }
    }
}
