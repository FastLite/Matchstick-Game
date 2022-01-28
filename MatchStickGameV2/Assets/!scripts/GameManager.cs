using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject endScreen;
    public bool gameIsEnded = false;
    public Slider sensativity;
    public Slider volume;
   

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

    private void Start()
    {
        if (PlayerPrefs.GetFloat("Volume") <0.1)
        {
            volume.value = 0.8f;
        }
        else
        {
            volume.value = PlayerPrefs.GetFloat("Volume");

        }
        sensativity.value = PlayerPrefs.GetFloat("sensitivity");
    }

   
    
    public void ChangeSensitivity(float newValue)
    {
        PlayerPrefs.SetFloat("sensitivity", newValue);
    }
    public void ChangeVolume(float newValue)
    {
        PlayerPrefs.SetFloat("Volume", newValue);
    }
    public void saveMuteState(int muted)
    {
        PlayerPrefs.SetInt("MuteState",muted);

    }

}
