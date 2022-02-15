using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSays : MonoBehaviour
{

    public Renderer rend;
    private Color firstColor = Color.white;
    private Color secondColor = Color.green;

    public int ThisButtonNumber;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = firstColor;
    }

    public void ChangeColor()
    {
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 0f); 
    }



}
