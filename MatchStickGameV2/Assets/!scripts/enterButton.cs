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

    public bool currentState, didplay;
    [SerializeField] private int offDelay;
    [SerializeField] private int onDelay;

     public bool delayed { get; set; }

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
        if (anim.isPlaying || delayed || didplay)
        {
            Debug.Log("Can't activate button, animation is still playing or events will happen automaticly");
        }
        else
        {
            if (!currentState)
            {
                Invoke(nameof(DoOnEvent), 0);
                
            }
            else if (type != ButtonType.OneTime)
            {
                Invoke(nameof(DoOffEvent), 0);
                
            }

            if (anim!=null)
            {
                anim.Play();
            }
        }
    }

    void DoOnEvent()
    {
        eventOn?.Invoke();
        currentState = !currentState ;
        if (offDelay>1)
        {
            delayed = true;
            Invoke(nameof(DoOffEvent), offDelay);
        }

        if (type == ButtonType.OneTime)
        {
            didplay = true;
        }

    }
    void DoOffEvent()
    {
        eventOff?.Invoke();
        currentState = !currentState ;
        if (onDelay>1)
        {
            delayed = true;
            Invoke(nameof(DoOnEvent), onDelay);
        }
    }
}
