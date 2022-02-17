using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FirePlaceManagment : MonoBehaviour
{
    public List<Fire> allObjects;
    private bool didPlay;
    public UnityEvent myEvent;
    public int delay;
    private void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
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
