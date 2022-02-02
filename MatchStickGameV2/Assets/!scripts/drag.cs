using System;
using System.Collections;
using System.Collections.Generic;
using CMF;
using UnityEngine;
using UnityEngine.Events;

public class drag : MonoBehaviour
{
    public Transform playerParent;
    public Transform rayPoint;
    public Transform currentBox;
    public AdvancedWalkerController controller;
    public Rigidbody playerRigidbody;
    public UnityEvent queue;
    [SerializeField]
    private bool hitbox = false;
    

    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(playerParent.transform.position, playerParent.forward, Color.green);
        if (Physics.Raycast(playerParent.position, playerParent.TransformDirection(Vector3.forward), out hit, .5f ) && hit.collider.gameObject.CompareTag("Box") )
        {
            hitbox = true;
        }
        else
        {
            hitbox = false;
        }

        if (currentBox !=null)
        {
            currentBox.localPosition = new Vector3(0, 0, 0);
        }

        if (hitbox && Input.GetButtonDown("Jump"))
        {
            currentBox = hit.collider.gameObject.transform;
                
                currentBox.parent = playerParent;
                int y = Mathf.FloorToInt(playerParent.transform.eulerAngles.y) ;
                if ((y< 95 && y >85) ||(y> 265 && y <280 ))
                {
                    controller.ignoreHorizontal = true;
                }
                else if ((y> -1 && y <2) || (y >175 && y <185))
                {
                    controller.ignoreVertical = true;
                } 
            
        }
        if (Input.GetButtonUp("Jump"))
        {
            if (currentBox ==null)
            {
                return;
            }
            controller.ignoreHorizontal = false;
            controller.ignoreVertical = false;
            currentBox.parent = null;
            currentBox = null;
        }
       
        
        
        

       
    }

    private void ResetConstraints()
    {
        currentBox.position.Set(0,0,0);

    }
}
