using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Btns : MonoBehaviour
{
    //public GameObject door_bttn1;
    //public GameObject door_bttn2;
    public GameObject door;
    public bool isDoorOpen;

    public int doorBttnsActive;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") || col.CompareTag("Box"))
        {
            doorBttnsActive++;
        }

        if (isDoorOpen)
        {
            return;
        }
        openDoor();
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player") || col.CompareTag("Box"))
        {
            doorBttnsActive--;
        }

    }

    public void openDoor()
    {
        if (doorBttnsActive == 2)
        {
            isDoorOpen = false;
            door.transform.position += new Vector3(0, 3, 0);
            Debug.Log("Door has been openned");           
        }
    }

}
