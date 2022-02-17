using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public GameObject toDestroy;
    public int targetCount = 2;    
    public int currentCount = 2;

    public void UpdateCount()
    {
        currentCount++;
        if (currentCount==targetCount)
        {
            Destroy(toDestroy);
        }
    }
}
