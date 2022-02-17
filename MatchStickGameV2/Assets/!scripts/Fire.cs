using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fire : MonoBehaviour
{
    //This script is placed on all the objects that can burn 
    protected enum FireSourceType
    {
         FirePlace, Rope 
    }
    [SerializeField] private bool lit;
     public GameObject fireVFX;

     [SerializeField] protected FireSourceType objectType;
     [SerializeField] private float radius;
     [SerializeField] private float delay = 1;


    

     public void InteractWithFire()
     {
         if (lit)
            return;
         switch (objectType)
         {
             case FireSourceType.FirePlace:
                 LightUpAndTransfer();
                 break;
             case FireSourceType.Rope:
                 LightUpAndTransfer();
                 break;
                 
         }
     }

     public void InteractWithFire(bool bypass)
     {
         if(!bypass)
             return;
         LightUpAndTransfer();
     }

     void TransferFire()
     {
          
         LayerMask mask = LayerMask.GetMask("Ignitable");
         var aray = Physics.OverlapSphere(transform.position, radius, mask, QueryTriggerInteraction.UseGlobal);
         foreach (var obj in aray)
         {
             var fi = obj.gameObject.GetComponent<Fire>();
             if (!fi.lit)
                 fi.InteractWithFire();

         }
     }
     [ContextMenu("transferfire debug")]
     void LightUpAndTransfer()
     {
         fireVFX.SetActive(true);
         lit = true;
         Invoke(nameof(TransferFire), delay);
     }

     private void OnDrawGizmos()
     {
         Gizmos.color = Color.red;
         Gizmos.DrawWireSphere(transform.position, radius);
     }
}
