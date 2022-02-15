using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    private SettingsSO so;
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

    }
}
