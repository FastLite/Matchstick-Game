using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraToNextLevel : MonoBehaviour
{
    [SerializeField] private float x, y, z;

    public virtual void Move()
    {
        var position = transform.position;
        position = new Vector3(position.x + x, position.y + y, position.z + z);
        transform.position = position;
    }

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
