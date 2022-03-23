using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Equation : MonoBehaviour
{
    public TextMesh textMesh;
     enum operation
    {
        Plus, Minus, Multiply, Done 
    }

     private operation op = operation.Plus;
    [SerializeField]private newPlate first;
    [SerializeField]private newPlate second;
    [SerializeField]private newPlate third;
    public UnityEvent doneEvent;
    private bool eventInvoked;
    public void Sum()
    {
        if (first.currentNumber+second.currentNumber == third.currentNumber)
        {
            RemoveBoxes();
            op = operation.Minus;
            textMesh.text = "-";
        }
    }
    public void Subtraction ()
    {
        if (first.currentNumber-second.currentNumber == third.currentNumber)
        {
            RemoveBoxes();
            op = operation.Multiply;
            textMesh.text = "X";

        }
    }
    public void Multiply()
    {
        if (first.currentNumber*second.currentNumber == third.currentNumber)
        {
            RemoveBoxes();
            op = operation.Done;

        }
    }

    private void Update()
    {
        if (first.inTrigger && second.inTrigger && third.inTrigger)
        {
            if (eventInvoked )
                return;
            
            switch (op)
            {
                case operation.Plus:
                    Sum();
                    break;
                case operation.Minus:
                    Subtraction();
                    break;
                case operation.Multiply:
                    Multiply();
                    break;
                
                case operation.Done:
                    DoEvent();
                    break;
                
            }
        }
    }
    private void DoEvent()
    {
        doneEvent.Invoke();
    }

    private void RemoveBoxes()
    {
        Destroy(first.current);
        Destroy(second.current);
        Destroy(third.current);
        Debug.Log("job done");
    }
}

