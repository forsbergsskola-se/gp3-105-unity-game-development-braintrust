﻿using UnityEngine;

namespace Systems.General
{
    [System.Serializable]
    public class Sound
    {
   
        public string soundName;
        public AudioClip audioClip;


        [Range(0f, 1f)]
        public float volume = 1f;

        public bool loop;


        [HideInInspector]
        public AudioSource source;

    }
}