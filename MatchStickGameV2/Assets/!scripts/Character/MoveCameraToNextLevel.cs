using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Place this script on the main camera of the scene
//Otherwise you can just turn on and off cameras to control what player sees
public class MoveCameraToNextLevel : MonoBehaviour
{
    [SerializeField] private float x, y, z;

    //No idea why I made it virtual but I will leave it here for now
    //Function is adding values to the camera transform
    public virtual void Move()
    {
        var position = transform.position;
        position = new Vector3(position.x + x, position.y + y, position.z + z);
        transform.position = position;
    }

    
    //set or change offset to each axis individualy
    public void UpdateX(float newX)
    {
        x = newX;
    }

    public void UpdateY(float newY)
    {
        y = newY;
    }

    public void UpdateZ(float newZ)
    {
        z = newZ;

    }
}
