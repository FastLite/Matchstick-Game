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

    public bool currentState { get; set; }
    public bool didplay;
    [SerializeField] private int offDelay;
    [SerializeField] private int onDelay;

     public bool delayed { get; set; }

    public void FindAndUpdateCounter()
    {
        FindObjectOfType<Counter>().UpdateCount();
    }

    public void StartSimonSaysGame()
    {
        FindObjectOfType<GameManager>().StartSSGame();
    }
    public void ChangeColor()
    {
        FindObjectOfType<SimonSays>().ChangeColor();
    }

    public void debug(string message)
    {
        Debug.Log(message);
    }

    public void Activate()
    {
        if (anim != null)
        {
            if ( anim.isPlaying || delayed || didplay)
            {
                debug("Can't activate button, animation is still playing or events will happen automaticly");
            }
        }
        else
        {
            if (!currentState)
            {
                Invoke(nameof(DoOnEvent), 0);
                debug("I am invoking button");

                
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
        if (eventOn.GetPersistentEventCount()<=0)
        {
            return;
        }
        currentState = !currentState;
        eventOn?.Invoke();

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
        if (eventOff.GetPersistentEventCount()<=0)
        {
            return;
        }
        eventOff?.Invoke();
        currentState = !currentState ;
        if (onDelay>1)
        {
            delayed = true;
            Invoke(nameof(DoOnEvent), onDelay);
        }
    }
}
