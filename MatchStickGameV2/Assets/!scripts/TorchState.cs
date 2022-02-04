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
   

    public MyEnum state;

    public void ChangeTorchState(MyEnum _state)
    {
        state = _state;
    }


    private void Update()
    {
        
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward, Color.green);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, .5f) )
            {
                GameObject go = hit.collider.gameObject;
                Debug.Log(go);
                if (Input.GetButton("Jump"))
                {
                    if (go.CompareTag("FirePlace"))
                    {
                        if (state == MyEnum.Without)
                        {
                            return;
                        }
                        else
                        {
                            go.GetComponent<Fire>().DoTheFlip(gameObject);
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
