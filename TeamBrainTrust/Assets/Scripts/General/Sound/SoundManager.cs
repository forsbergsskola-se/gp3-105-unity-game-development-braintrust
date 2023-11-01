using System;
using UnityEngine;

namespace Systems.General
{
    public class SoundManager : MonoBehaviour
    {
    
        public static float soundVolume = 0.5f;
        public static float musicVolume = 0.5f;
        static SoundManager i;
        public Sound[] sounds;


        private void Awake()
        {
            i = this;

            foreach (Sound sound in sounds)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.audioClip;

                sound.source.volume = sound.volume * soundVolume;
                sound.source.loop = sound.loop;


                if (sound.soundName == "Ambience" || sound.soundName == "Main_Menu")
                    sound.source.volume = sound.volume * musicVolume;
            }

        }

        // public void ChangeValue()
        // {
        //     foreach (Sound sound in sounds)
        //     {
        //         sound.source.volume = sound.volume * soundVolume;
        //         sound.source.loop = sound.loop;
        //
        //         if (sound.soundName == "Game_Music" || sound.soundName == "Main_Menu")
        //         {
        //             sound.source.volume = sound.volume * musicVolume;
        //             Debug.Log(sound.soundName + sound.source.volume);
        //         }
        //     }
        // }


        void GetSound(string soundName)
        {
            Sound sound = Array.Find(sounds, sound => sound.soundName == soundName);
            Sound soundAlt = Array.Find(sounds, sound => sound.audioClip.name == soundName);

            if (sound != null)
            {
                sound.source.Play();
                return;
            }
            if(soundAlt != null)
            {
                soundAlt.source.Play();
                return;
            }
    
            Debug.Log("Can't Find: " + soundName);
        }


        public static void PlaySound(string soundName)
        {
            i.GetSound(soundName);
        }

    }
}