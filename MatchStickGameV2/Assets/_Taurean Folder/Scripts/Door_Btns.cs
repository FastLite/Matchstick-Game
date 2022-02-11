using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Btns : MonoBehaviour
{
    //public GameObject door_bttn1;
    //public GameObject door_bttn2;
    public GameObject door;
    public bool isDoorOpen;


    void OnTriggerEnter(Collider col)
    {      
        door.transform.position += new Vector3(0, 3, 0);
        Debug.Log("Door has been openned");
        isDoorOpen = false;
    }
}
