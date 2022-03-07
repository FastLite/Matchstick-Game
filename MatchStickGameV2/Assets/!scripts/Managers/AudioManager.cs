using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public SoundCollectionSO sc;
    public static AudioManager instance;
    public AudioMixer masterMixer;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad (gameObject); 
    }
    public void playAudioClip(AudioSource audioSource, AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
    
    public void  VolumeUpdate(string varName, float value)
    {
        masterMixer.SetFloat(varName, value);
    }
}
