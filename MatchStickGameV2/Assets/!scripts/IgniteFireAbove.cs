using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgniteFireAbove : MonoBehaviour
{    [SerializeField]
     GameObject torch;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FirePlace"))
        {
            other.GetComponent<Fire>().DoTheFlip(torch);
        }
    }
}
