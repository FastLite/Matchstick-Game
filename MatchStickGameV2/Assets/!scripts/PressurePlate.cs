using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PressurePlate : MonoBehaviour
{
    public UnityEvent onAction;
    public UnityEvent offAction;
    [SerializeField]private bool oneTime;
    [SerializeField]private bool wasOn;

    [SerializeField] private float distanceCheck = 0.05f;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);
            if (distance<distanceCheck)
            {
                if (!wasOn)
                {
                    onAction.Invoke();
                }

                wasOn = true;

            }
            else if (!oneTime)
            {
                if (wasOn)
                {
                    offAction.Invoke();
                }

                wasOn = false;
            }
        }
    }
    
}
