using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlate : MonoBehaviour
{
    public int currentNumber;
    public bool inTrigger;
    [SerializeField] private float distanceCheck = 0.3f;
    public GameObject current;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            current= other.gameObject;
            float distance = Vector3.Distance(transform.position, other.transform.position);
            if (distance<distanceCheck)
            {
                inTrigger = true;
                currentNumber = other.gameObject.GetComponent<NumberContainer>().number;
            }
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        currentNumber = 0;
        current = null;
    }
}
