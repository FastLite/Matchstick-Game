using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PressurePlate : MonoBehaviour
{
    public UnityEvent queue;

    [SerializeField] private float distanceCheck = 0.05f;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);
            Debug.Log(distance);
            if (distance<distanceCheck)
            {
                MeshRenderer render = GetComponent<MeshRenderer>();
                if (render!= null)
                {
                    render.material.color = Color.blue;
                }
                Destroy(this);
            }
        }
    }
    
}
