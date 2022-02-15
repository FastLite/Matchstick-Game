using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;
[CreateAssetMenu(fileName = "Settings", menuName = "assets/Settings", order = 1)]

[Serializable]
public class SettingsSO : ScriptableObject
{
    public float globalVolume, musicVolume, soundVolume;
    public bool muteState;
}
