using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject PauseCanvas;
    public GameObject settingsCanvas;
    public GameObject mainCam;
    private bool pauseActive = false;
    public  AudioListener pLayerListener;
    private void Start()
    {
        
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    public void PauseUnpause()
    {
            switch (pauseActive)
            {
                case false:
                    TurnOnUI();
                    break;
                case true:
                    TurnOffUI();
                    break;
            }
    }

    // Update is called once per frame
    void Update()
    {if (Input.GetKeyDown(KeyCode.Escape))
        PauseUnpause();
    }

    void TurnOnUI()
    {
        PauseCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
        pauseActive = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        AudioListener.pause = true; 
    }

    void TurnOffUI()
    {
        PauseCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        pauseActive = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        AudioListener.pause = false; 
    }
}
