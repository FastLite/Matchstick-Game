using System;
using System.IO;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    public SettingsSO so;

    public static SettingsManager instance;
    public string currentVarName;
    string saveFile = Application.dataPath + "/settings.json";


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
        ReadFromJson();
    }

    public void SaveInJson()
    {
        var objectToSave = so;
        var write = JsonUtility.ToJson(objectToSave, true);
        File.WriteAllText(saveFile, write);
    }

    void ReadFromJson()
    {
        if (!File.Exists(saveFile))
            return;
        string fileContents = File.ReadAllText(saveFile);
        JsonUtility.FromJsonOverwrite(fileContents, so);
        /*if (so.globalVolume > 0)
        {
            so.globalVolume = 0;
        }
        if (so.musicVolume > 20)
        {
            so.musicVolume = 20;
        }
        if (so.soundVolume > 20)
        {
            so.soundVolume = 20;
        }
        
        if (so.globalVolume < -40)
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
        }*/
        SetNewMasterVolume(so.globalVolume);
        SetNewMusicVolume(so.musicVolume);
        SetNewSoundVolume(so.soundVolume);
    }

    public void sliderString(string va)
    {
        currentVarName = va;
    }

    public void SetNewMasterVolume(float volume)
    {
        so.globalVolume = volume;
        AudioManager.instance.VolumeUpdate("masterVolume",volume);
    }
    public void SetNewSoundVolume(float volume)
    {
        so.musicVolume = volume;

        AudioManager.instance.VolumeUpdate("soundVolume",volume);

    }
    public void SetNewMusicVolume(float volume)
    {
        so.soundVolume = volume;

        AudioManager.instance.VolumeUpdate("musicVolume",volume);

    }

}
