using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    private SettingsSO so;

    public string currentVarName;
    string saveFile = Application.dataPath + "/settings.json";
    
    void SaveInJson()
    {
        var objectToSave = so;
        var write = JsonUtility.ToJson(so, true);
        File.WriteAllText(saveFile, write);
    }

    void ReadFromJson()
    {
        if (!File.Exists(saveFile))
            return;
        string fileContents = File.ReadAllText(saveFile);
        so = JsonUtility.FromJson<SettingsSO>(fileContents);
        if (so.globalVolume > 100)
        {
            so.globalVolume = 100;
        }
        if (so.musicVolume > 100)
        {
            so.musicVolume = 100;
        }
        if (so.soundVolume > 100)
        {
            so.soundVolume = 100;
        }
        
        if (so.globalVolume < 0)
        {
            so.globalVolume = 0;
        }
        if (so.musicVolume < 0)
        {
            so.musicVolume = 0;
        }
        if (so.soundVolume < 0)
        {
            so.soundVolume = 0;
        }
    }

    public void sliderString(string va)
    {
        currentVarName = va;
    }

    public void SetNewMasterVolume(float volume)
    {
        so.globalVolume = volume;
        AudioManager.instance.VolumeUpdate("masterVolume",volume-100);
    }
    public void SetNewSoundVolume(float volume)
    {
        so.musicVolume = volume;

        AudioManager.instance.VolumeUpdate("soundVolume",volume-100);
    }
    public void SetNewMusicVolume(float volume)
    {
        so.soundVolume = volume;

        AudioManager.instance.VolumeUpdate("musicVolume",volume-100);
    }

}
