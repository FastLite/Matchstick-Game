using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<Counter>().UpdateCount();
        Destroy(gameObject);
        
    }
}
