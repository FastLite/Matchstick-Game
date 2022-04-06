using UnityEngine;

public class Fire : MonoBehaviour
{
    //This script is placed on all the objects that can burn 
    //For now the only difference between rope and fireplace is that fireplace can be ignited by the playe and a rope can't
    protected enum FireSourceType
    {
        FirePlace, Rope 
    }

    [SerializeField] public bool lit;
    public GameObject fireVFX;//Gameobject with fire VFX or particle system, whateever we will use

    [SerializeField] protected FireSourceType objectType;
    [SerializeField] private float radius;//radius for the sphere check to pass the flame onto the next object
    [SerializeField] private float delay = 1;//delay for passing the flame
    public bool continueChecking;

    /// <summary>
    /// Called when the object should be ignite by something
    /// </summary>
    public void InteractWithFire()
    {
        if (!continueChecking)
        {
            if (lit)
                return;
        }
        
        switch (objectType)
        {
            case FireSourceType.FirePlace:
                LightUpAndTransfer();
                //TODO add extinguishing here
                break;
            case FireSourceType.Rope:
                LightUpAndTransfer();
                break;
        }
    }

    //useless for now override
    public void InteractWithFire(bool bypass)
    {
        if(!bypass)
            return;
        LightUpAndTransfer();
    }

    void TransferFire()
    {
        LayerMask mask = LayerMask.GetMask("Ignitable");//Detect objects only on "Ignitable" layer
        //Get array of colliders and store them in variable
        var aray = Physics.OverlapSphere(transform.position, radius, mask, QueryTriggerInteraction.UseGlobal);
        foreach (var obj in aray)
        {
            var fi = obj.gameObject.GetComponent<Fire>();
            if (!fi.lit)//if not burning, start burning and pass flame
                fi.InteractWithFire();

        }
    }
    [ContextMenu("transferfire debug")]//trigger transfering on an object in playmode without interacting with character
    void LightUpAndTransfer()
    {
        fireVFX.SetActive(true);
        lit = true;
        if (objectType == FireSourceType.FirePlace)
        {
            if (GetComponentInParent<FirePlaceManagment>()!=null)
                GetComponentInParent<FirePlaceManagment>().CheckObjectsInlist();
        }
        Invoke(nameof(TransferFire), delay);//transfer fire after a set delay
        
        
        if (!continueChecking)
            return;
        Invoke(nameof(InteractWithFire), 1);// constant check each second until destroyed if needed
    }

    
    //Show red spheres in editor which will show radius of a sphere check
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}