using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Temperature : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    [SerializeField]private int flameValue;
    [SerializeField]private int targetValue;

    private void Start()
    {
        NewText();
    }

    public void ChangeValue(int value)
    {
        
        if (flameValue==targetValue)
        {
            return;
        }
        
        flameValue = flameValue + value;
        if (flameValue>400)
        {
            flameValue -= 400;
        }
        NewText();
        if (flameValue==targetValue)
        {
            text.color = Color.green;
            Debug.Log("Target temperature achieved");
            
            return;
        }
        
        
    }

    public void ResetTemperature(int defaultTemp)
    {
        flameValue = defaultTemp;
    }

    [ContextMenu(nameof(NewText))]public void NewText()
    {
        text.text = flameValue+"°C";

    }
}
 