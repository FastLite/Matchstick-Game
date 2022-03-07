using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "Audio", menuName = "assets/Audio", order = 1)]

public class SoundCollectionSO : ScriptableObject
{
    //music collection for each area
    //TODO add area for individual tracks for special occasions 
    [Header("Music")]
    public List<AudioClip> area1Music;
    public List<AudioClip> area2Music;
    public List<AudioClip> area3Music;
    public List<AudioClip> area4Music;
    
    [Space(10)]
    [Header("SFX")]
    public List<AudioClip> stepSounds;
    public AudioClip UIClick;
    public AudioClip buttonPositive, buttonNegative;  
    public AudioClip pressurePlate;
    public AudioClip fireOn, fireOff;
    public AudioClip doorOpen;
    
}
