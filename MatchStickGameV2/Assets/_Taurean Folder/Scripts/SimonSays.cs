using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSays : MonoBehaviour
{
    [SerializeField]
    private bool active;

    private GameObject button;

    private Renderer buttonRenderer;

    private Color newButtonColor;

    private float colorOne, colorTwo;

    private AudioSource rightSound;


    void Start()
    {
        buttonRenderer = button.GetComponent<Renderer>();
        gameObject.GetComponent<Button>().onClick.AddListener(ChangeBoxColor);
    }

  



    public void ChangeBoxColor()
    {
        colorOne = Random.Range(0f, 1f);
        colorTwo = Random.Range(0f, 1f);

        newButtonColor = new Color(colorOne, colorTwo, 1f);

        buttonRenderer.material.SetColor("_color", newButtonColor);
    }
}
