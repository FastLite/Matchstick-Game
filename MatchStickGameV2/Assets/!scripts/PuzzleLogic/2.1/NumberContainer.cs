using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberContainer : MonoBehaviour
{
    public int number;
    private void Start()
    {
        ChangeNumber();
    }

    [ContextMenu(nameof(ChangeNumber))]public void ChangeNumber()
    {
        gameObject.GetComponentInChildren<TextMeshPro>().text = number.ToString();

    }
}
