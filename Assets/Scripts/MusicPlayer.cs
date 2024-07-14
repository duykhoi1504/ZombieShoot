using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicPlayer : MonoBehaviour
{
    [SerializeField] Sound[] musicSounds, sfxSounds;
    public static MusicPlayer Instant;
    public AudioSource musicSource, sfxSource;
    [System.Serializable]
    private class Sound
    {
        public string name;
        public AudioClip clip;
    }

    // Start is called before the first frame update
    // private void Awake() {
    //     int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
    //     if (numMusicPlayer > 1) {
    //         Destroy(gameObject);
    //     }else{
    //         DontDestroyOnLoad(gameObject);
    //     }
    // }

    private void Awake()
    {
        
        if (Instant == null)
        {
            Instant = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        MusicPlayer.Instant.PlayMusic("theme");
    }


    public void PlayMusic(string name)
    {
        Sound s = null;
        foreach (Sound sound in musicSounds)
        {
            if (sound.name == name)
            {
                s = sound;
                break;
            }
        }

        if (s == null)
        {
            Debug.Log("Sound not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }

    }
    public void PLaySFX(string name)
    {
        Sound s = null;
        foreach (Sound sound in sfxSounds)
        {
            if (sound.name == name)
            {
                s = sound;
                break;
            }
        }

        if (s == null)
        {
            Debug.Log("sfx not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
        //Sound s = Array.Find(sfxSounds, x => x.name == name);
        //if (s == null)
        //{
        //    Debug.Log("Sound not Found");
        //}
        //else
        //{
        //    sfxSource.PlayOneShot(s.clip);
        //}
    }
    public void MusicVolume(float volumn)
    {
        musicSource.volume = volumn;
    }
    public void SFXVolume(float volumn)
    {
        sfxSource.volume = volumn;
    }
//    public void FootStepSFX(string name)
//     {
//         sfxSource.pitch = UnityEngine.Random.Range(0.8f, 1f);
//         PLaySFX(name);
//     }
}
