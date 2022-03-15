using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSliderValue : MonoBehaviour
{
    protected enum type
    {
       master, music, sfx
    }

    [SerializeField]protected type tipe;
    void Start()
    {
        switch (tipe)
        {
            case type.master:
                gameObject.GetComponent<Slider>().value = SettingsManager.instance.so.globalVolume;
                break;
            case type.music:
                gameObject.GetComponent<Slider>().value = SettingsManager.instance.so.musicVolume;
                break;
            case type.sfx:
                gameObject.GetComponent<Slider>().value = SettingsManager.instance.so.soundVolume;
                break;
        }
    }

}
