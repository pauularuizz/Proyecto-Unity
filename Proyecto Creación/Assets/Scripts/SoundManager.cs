﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[]audios;
    private AudioSource controlAudio;
    private void Awake()
    {
        controlAudio = GetComponent<AudioSource>();

    }
    public void AudioSelector(int index, float vol)
    {
        controlAudio.PlayOneShot(audios[index], vol);
    }
}
