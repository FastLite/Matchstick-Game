using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enterButton : MonoBehaviour
{
    public enum ButtonType
    {
        OneTime, Repeatable
    }

    public ButtonType type = ButtonType.Repeatable;
    
    
    public UnityEvent eventOn;
    public UnityEvent eventOff;
    public Animation anim;

    public bool currentState;

    public void FindAndUpdateCounter()
    {
        FindObjectOfType<Counter>().UpdateCount();
    }

    public void debug()
    {
        Debug.Log("EventStarted");
    }

    public void Activate()
    {
        if (anim.isPlaying)
        {
            Debug.Log("Can't activate button, animation is still playing");
        }
        else
        {
            if (!currentState)
            {
                eventOn?.Invoke();
                currentState = !currentState ;
            }
            else if (type != ButtonType.OneTime)
            {
                eventOff?.Invoke();
                currentState = !currentState ;
            }

            if (anim!=null)
            {
                anim.Play();
                Debug.Log(eventOn);
            }
        }
        

        

    }
}
