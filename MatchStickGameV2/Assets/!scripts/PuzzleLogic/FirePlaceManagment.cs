using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FirePlaceManagment : MonoBehaviour
{
    public List<Fire> allObjects;//add all objects you want to be tied together in this list
    //TODO replace didplay with something that will allow extinguishing 
    private bool didPlay = false;//makes sure trigger only activates once
    public UnityEvent myEvent;
    public int delay;
    
    private void DoEvent()
    {
        myEvent.Invoke();
    }

    public void CheckObjectsInlist()
    {
        
        foreach (var fire in allObjects)
        {
            if (!fire.lit)
                return;
        }
        if (didPlay) return;
        didPlay = true;
        if (myEvent.GetPersistentEventCount()>0)
        {
            Invoke(nameof(DoEvent), delay);
        }
    }
}
