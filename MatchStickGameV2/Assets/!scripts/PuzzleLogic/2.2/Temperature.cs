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
        text.text = flameValue.ToString();    
        NewText();
    }

    public void ChangeValue(int value)
    {
        flameValue = flameValue + value;
        if (flameValue>400)
        {
            flameValue -= 400;
        }
        else if (flameValue==targetValue)
        {
          Debug.Log("Target temperature achived");
        }

        NewText();
    }
    
    [ContextMenu(nameof(NewText))]public void NewText()
    {
        text.text = flameValue+"°C";

    }
}
