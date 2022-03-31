using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingMusic : MonoBehaviour
{
    public Sound introTrack;
    public Sound loopingAudio;
    private Sound current;
    private bool paused;
    private void Awake()
    {
        introTrack.source = gameObject.AddComponent<AudioSource>();
        introTrack.source.playOnAwake = true;
        introTrack.source.clip = introTrack.clip;
        introTrack.source.loop = introTrack.loop;

        loopingAudio.source = gameObject.AddComponent<AudioSource>();
        loopingAudio.source.playOnAwake = false;
        loopingAudio.source.clip = loopingAudio.clip;
        loopingAudio.source.loop = loopingAudio.loop;

        Reset();
    }
    private void Update()
    {
        if (!(current.source.isPlaying || paused)) {
            current = loopingAudio;
            current.source.Play();
        }
    }
    public void Reset()
    {
        paused = false;
        current = introTrack;
        current.source.Play();
    }
    public void Pause()
    {
        paused = true;
        current.source.Pause();
    }
    public void UnPause() {
        paused = false;
        current.source.UnPause();
    } 
}
