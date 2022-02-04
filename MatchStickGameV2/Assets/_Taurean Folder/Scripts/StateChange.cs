using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChange : MonoBehaviour
{
    public GameObject puzzleCube;
    private Material yellowMesh;
    //public Renderer greenMesh;

    public bool buttonActive;
    // Start is called before the first frame update
    void Start()
    {
        //yellowMesh = GetComponent<Renderer>();    
    }

    // Update is called once per frame
    public void changeColor()
    {
        if (buttonActive)
        {
            yellowMesh.color = Color.cyan;
            Debug.Log("Im green!");
        }
        //else if (!buttonActive)
        //{
        //    yellowMesh.color = Color.white;
        //    Debug.Log("Im yellow!");
        //}
    }

    private void Update()
    {
        changeColor();
    }
}
