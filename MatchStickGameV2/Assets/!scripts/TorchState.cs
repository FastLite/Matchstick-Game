using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchState : MonoBehaviour
{
   public enum MyEnum
    {
        WithTorch,Without
    }

   public GameObject torchGO;

   private Transform raycastPoint;
    public MyEnum state;

    public void ChangeTorchState(MyEnum _state)
    {
        state = _state;
    }

    private void Start()
    {
        raycastPoint = gameObject.GetComponent<Interact>().rayPoint;
    }


    private void Update()
    {
        
            RaycastHit hit;
            Debug.DrawRay(raycastPoint.position, raycastPoint.forward, Color.green);
            if (Physics.Raycast(raycastPoint.position, raycastPoint.TransformDirection(Vector3.forward), out hit, .5f) )
            {
                GameObject go = hit.collider.gameObject;
                if (Input.GetButton("Jump"))
                {
                    if (go.CompareTag("FirePlace"))
                    {
                        if (state == MyEnum.Without)
                        {
                        }
                        else
                        {
                            go.GetComponent<Fire>().InteractWithFire(gameObject);
                        }
                    }
                    else if (go.CompareTag("TorchPile"))
                    {
                        if (state == MyEnum.Without)
                        {
                            torchGO.SetActive(true);
                            state = MyEnum.WithTorch;
                        }
                        else
                        {
                            return;
                            //torchGO.SetActive(false);
                        }
                    }

                }
            }

          
            
    }
}
