using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enterButton : MonoBehaviour
{
    public UnityEvent eventOn;
    public UnityEvent eventOff;
    public Animation anim;

    public bool currentState;

    public void FindAndUpdateCounter()
    {
        FindObjectOfType<Counter>().UpdateCount();
    }

    public void Activate()
    {
        if (currentState)
        {
            eventOn?.Invoke();
        }
        else
        {
            eventOff?.Invoke();
        }

        if (anim!=null)
        {
            anim.Play();
        }

        

    }
}
