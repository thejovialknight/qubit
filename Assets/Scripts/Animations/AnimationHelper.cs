using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHelper : MonoBehaviour
{
    public Vector3 currentRotationSpeed;
    public Vector3 currentSize;

    public Vector3 rotationSpeed;
    public Vector3 size;

    void Update()
    {
        transform.localScale = currentSize;
        transform.Rotate(currentRotationSpeed * 360f * Time.deltaTime);
    }

    public void Scale(float speed)
    {
        currentSize += new Vector3(speed * size.x, speed * size.y, speed * size.z) * Time.deltaTime;
    }

    public void ScaleTowardsTarget(float speed)
    {
        if(currentSize.x < size.x)
        {
            currentSize.x += speed * size.x * Time.deltaTime;
        }
        else
        {
            currentSize.x = size.x;
        }

        if (currentSize.y < size.y)
        {
            currentSize.y += speed * size.y * Time.deltaTime;
        }
        else
        {
            currentSize.y = size.y;
        }

        if (currentSize.z < size.z)
        {
            currentSize.z += speed * size.z * Time.deltaTime;
        }
        else
        {
            currentSize.z = size.z;
        }
    }

    public void AccelerateRotation(float speed)
    {
        currentRotationSpeed += new Vector3(speed * rotationSpeed.x, speed * rotationSpeed.y, speed * rotationSpeed.z) * Time.deltaTime;
    }

    public void AccelerateRotationTowardsTarget(float speed)
    {
        if (currentRotationSpeed.x < rotationSpeed.x)
        {
            currentRotationSpeed.x += speed * rotationSpeed.x * Time.deltaTime;
        }
        else
        {
            currentRotationSpeed.x = rotationSpeed.x;
        }

        if (currentRotationSpeed.y < rotationSpeed.y)
        {
            currentRotationSpeed.y += speed * rotationSpeed.y * Time.deltaTime;
        }
        else
        {
            currentRotationSpeed.y = rotationSpeed.y;
        }

        if (currentRotationSpeed.z < rotationSpeed.z)
        {
            currentRotationSpeed.z += speed * rotationSpeed.z * Time.deltaTime;
        }
        else
        {
            currentRotationSpeed.z = rotationSpeed.z;
        }
    }

    public bool IsTooSmall()
    {
        return currentSize.x < size.x || currentSize.y < size.y || currentSize.z < size.z;
    }

    public bool IsRotatingTooSlowly()
    {
        return currentRotationSpeed.x < rotationSpeed.x || currentRotationSpeed.y < rotationSpeed.y || currentRotationSpeed.z < rotationSpeed.z;
    }
}
