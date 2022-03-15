using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Slider volume;

    [SerializeField]
    public Renderer[] boxes;
    private int boxSelect;

    public float stayLit;
    private float stayLitCounter;
    

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
    
    public void StartSSGame()//TODO move this function to another script, it doesn't belong here
    {
        boxSelect = UnityEngine.Random.Range(0, boxes.Length);

        boxes[boxSelect].material.color = new Color(boxes[boxSelect].material.color.r, boxes[boxSelect].material.color.b, boxes[boxSelect].material.color.g, 1f);

        stayLitCounter = stayLit;

        if (stayLitCounter > 1)
        {
            stayLitCounter -= Time.deltaTime;
        }
        else
        {
            boxes[boxSelect].material.color = new Color(boxes[boxSelect].material.color.r, boxes[boxSelect].material.color.b, boxes[boxSelect].material.color.g, 0.5f);
        }
    }

    public void ColorPressed(int whichButton)
    {
        //if()
    }


}
