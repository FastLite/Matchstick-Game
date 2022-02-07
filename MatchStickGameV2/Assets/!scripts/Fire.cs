using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fire : MonoBehaviour
{
    
     enum FireSourceType
    {
        Torch, FirePlace, Rope 
    }

     public GameObject fire;
     private bool lit;

     [SerializeField] private FireSourceType objectType;

     public void InteractWithFire(GameObject o)
     {
         switch (objectType)
         {
             /*case FireSourceType.Torch:
                 if (o.GetComponent<TorchState>().state == TorchState.MyEnum.WithTorch)
                 {
                     
                 }
                 else
                 {
                     gameObject.transform.parent = o.transform;
                 }
                 break;*/
             case FireSourceType.FirePlace:
                 if (o.GetComponent<TorchState>().state == TorchState.MyEnum.WithTorch)
                 {
                     
                     lit = true;
                     fire.SetActive(true);
                 }
                 break;
                 //Check for torch
             case FireSourceType.Rope:
                 //check for fire
                 if (lit )
                 {
                     
                 }
                 else
                 {
                     lit = true;
                 }
                 break;
                 
         }
     }
}
