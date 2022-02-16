using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fire : MonoBehaviour
{
    //This script is placed on all the objects that can burn 
    protected enum FireSourceType
    {
        Torch, FirePlace, Rope 
    }
    public GameObject fire;
     private bool lit;
     public GameObject fireVFX;

     [SerializeField] protected FireSourceType objectType;

     
     
     public void InteractWithFire(GameObject gm)
     {
         // gm - is object that transfers the fire
         // gp - short local variable to get the other object fire state
         var gp = gm.GetComponent<TorchState>().state;
         switch (objectType)
         {
             case FireSourceType.Torch:
                 if (gp == TorchState.MyEnum.WithTorch)
                 {
                 }
                 else
                 {
                     gameObject.transform.parent = gm.transform;
                 }
                 break;
             case FireSourceType.FirePlace:
                 if (gp == TorchState.MyEnum.WithTorch)
                 {
                     lit = true;
                     fire.SetActive(true);
                 }

                 lightUpAndTransfer();
                 break;
             case FireSourceType.Rope:
                 lightUpAndTransfer();
                 break;
                 
         }
     }

     public void InteractWithFire(bool bypass)
     {
         if(false)
             return;
         
     
     }

     void TransferFire()
     {
         var aray = Physics.OverlapSphere(transform.position, 1, 1, QueryTriggerInteraction.UseGlobal);
         foreach (var obj in aray)
         {
             var fi = obj.gameObject.GetComponent<Fire>();
             if (fi.lit)
                return;
             InteractWithFire(obj.gameObject);
         }
     }

     void lightUpAndTransfer()
     {
         lit = true;
         TransferFire();
     }
}
