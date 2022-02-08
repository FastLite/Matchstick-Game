using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomTrigger : MonoBehaviour
{
  
    public GameObject myObject;
    private bool didPlay;
    public UnityEvent myEvent;
    public int delay;
    
    
    
    
    private void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (didPlay) return;
        didPlay = true;
        if (myEvent.GetPersistentEventCount()>0)
        {
            Debug.Log(myEvent.GetPersistentEventCount());
            Invoke(nameof(DoEvent), delay);
        }
    }

    private void DoEvent()
    {
        myEvent.Invoke();
    }
    
}
