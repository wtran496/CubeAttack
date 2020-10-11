﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musical : MonoBehaviour
{
    public AudioSource BGM;
    
    public void ChangeBGM(AudioClip music)
    {
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }

}
