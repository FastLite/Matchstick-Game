using System;
using System.Collections;
using System.Collections.Generic;
using CMF;
using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{
    public Transform playerParent;
    public Transform rayPoint;
    public Transform currentBox;
    public AdvancedWalkerController controller;
    private TurnTowardControllerVelocity TTCV;

    private void Awake()
    {
        TTCV = GetComponentInChildren<TurnTowardControllerVelocity>();
    }

    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(rayPoint.transform.position, rayPoint.forward, Color.green);
        if (Physics.Raycast(rayPoint.position, rayPoint.TransformDirection(Vector3.forward), out hit, .5f ))
        {
            GameObject go = hit.collider.gameObject;
            if (go.CompareTag("Box"))
            {
                if (Input.GetButtonDown("Jump"))
                {
                    PickUpBox(go.transform);
                }

                if (Input.GetButtonUp("Jump"))
                {
                    ReleaseBox();
                }
            }
            else if (go.CompareTag("Button"))
            {
                if (Input.GetButtonDown("Jump"))
                {
                    go.GetComponent<enterButton>().Activate();
                }
            }
            
        }
    }

    void PickUpBox(Transform box)
    {
        currentBox = box;
        currentBox.position.Set(0,0,0);
        currentBox.parent = playerParent;
        int y = Mathf.FloorToInt(playerParent.transform.eulerAngles.y) ;
        TTCV.enabled = false;
        if ((y< 95 && y >85) ||(y> 265 && y <280 ))
        {
            controller.ignoreHorizontal = true;
        }
        else if ((y> -1 && y <2) || (y >175 && y <185))
        {
            controller.ignoreVertical = true;
        }
    }
    private void ReleaseBox()
    {
        if (currentBox ==null)
        {
            return;
        }
        GetComponentInChildren<TurnTowardControllerVelocity>().enabled = true;
        controller.ignoreHorizontal = false;
        controller.ignoreVertical = false;
        currentBox.parent = null;
        currentBox = null;
    }
}