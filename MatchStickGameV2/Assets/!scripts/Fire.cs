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
         var gp = o.GetComponent<TorchState>().state;
         switch (objectType)
         {
             case FireSourceType.Torch:
                 if (gp == TorchState.MyEnum.WithTorch)
                 {
                     
                 }
                 else
                 {
                     gameObject.transform.parent = o.transform;
                 }
                 break;
             case FireSourceType.FirePlace:
                 if (gp == TorchState.MyEnum.WithTorch)
                 {
                     
                     lit = true;
                     fire.SetActive(true);
                 }
                 break;
             case FireSourceType.Rope:
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
