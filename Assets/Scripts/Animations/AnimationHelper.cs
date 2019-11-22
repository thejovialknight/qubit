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

    public void ScaleTowardsTarget(float speed, bool ignoreX, bool ignoreY, bool ignoreZ)
    {
        ScaleTowards(size, speed, ignoreX, ignoreY, ignoreZ);
    }

    public void ScaleTowardsTarget(float speed)
    {
        ScaleTowardsTarget(speed, false, false, false);
    }

    public void ScaleTowards(Vector3 scale, float speed, bool ignoreX, bool ignoreY, bool ignoreZ)
    {
        if(!ignoreX) 
        {
            if(currentSize.x < scale.x)
            {
                currentSize.x += speed * size.x * Time.deltaTime;
            }
            else if(currentSize.x > scale.x)
            {
                currentSize.x -= speed * size.x * Time.deltaTime;
            }
            else
            {
                currentSize.x = scale.x;
            }
        }

        if(!ignoreY) 
        {
            if(currentSize.y < scale.y)
            {
                currentSize.y += speed * size.y * Time.deltaTime;
            }
            else if(currentSize.y > size.y)
            {
                currentSize.y -= speed * size.y * Time.deltaTime;
            }
            else
            {
                currentSize.y = scale.y;
            }
        }

        if(!ignoreZ)
        {
            if(currentSize.z < scale.z)
            {
                currentSize.z += speed * size.z * Time.deltaTime;
            }
            else if(currentSize.z > scale.z)
            {
                currentSize.z -= speed * size.z * Time.deltaTime;
            }
            else
            {
                currentSize.z = scale.z;
            }
        }
    }

    public void ScaleTowards(Vector3 scale, float speed) 
    {
        ScaleTowards(scale, speed, false, false, false);
    }

    public void AccelerateRotation(float speed)
    {
        currentRotationSpeed += new Vector3(speed * rotationSpeed.x, speed * rotationSpeed.y, speed * rotationSpeed.z) * Time.deltaTime;
    }

    public void AccelerateRotationTowards(Vector3 rotation, float speed, bool ignoreX, bool ignoreY, bool ignoreZ)
    {
        if(!ignoreX)
        { 
            if (currentRotationSpeed.x < rotation.x)
            {
                currentRotationSpeed.x += speed * rotation.x * Time.deltaTime;
            }
            else if (currentRotationSpeed.x > rotation.x)
            {
                currentRotationSpeed.x -= speed * rotation.x * Time.deltaTime;
            }
            else
            {
                currentRotationSpeed.x = rotation.x;
            }
        }

        if(!ignoreY) 
        {
            if (currentRotationSpeed.y < rotation.y)
            {
                currentRotationSpeed.y += speed * rotation.y * Time.deltaTime;
            }
            else if (currentRotationSpeed.y > rotation.y)
            {
                currentRotationSpeed.y -= speed * rotation.y * Time.deltaTime;
            }
            else
            {
                currentRotationSpeed.y = rotation.y;
            }
        }

        if(!ignoreZ) 
        {
            if (currentRotationSpeed.z < rotation.z)
            {
                currentRotationSpeed.z += speed * rotation.z * Time.deltaTime;
            }
            else if (currentRotationSpeed.z > rotation.z)
            {
                currentRotationSpeed.z -= speed * rotation.z * Time.deltaTime;
            }
            else
            {
                currentRotationSpeed.z = rotation.z;
            }
        }
    }
    
    public void AccelerateRotationTowards(Vector3 rotation, float speed) 
    {
        AccelerateRotationTowards(rotation, speed, false, false, false);
    }

    public void AccelerateRotationTowardsTarget(float speed, bool ignoreX, bool ignoreY, bool ignoreZ)
    {
        AccelerateRotationTowards(rotationSpeed, speed, ignoreX, ignoreY, ignoreZ);
    }

    public void AccelerateRotationTowardsTarget(float speed)
    {
        AccelerateRotationTowardsTarget(speed, false, false, false);
    }

    public bool IsTooLarge(Vector3 desiredSize, bool ignoreX, bool ignoreY, bool ignoreZ)
    {
        bool isTooLarge = false;
        if(!ignoreX && currentSize.x > desiredSize.x) 
            isTooLarge = true;

        if(!ignoreY && currentSize.y > desiredSize.y) 
            isTooLarge = true;

        if(!ignoreZ && currentSize.z > desiredSize.z) 
            isTooLarge = true;
        
        return isTooLarge;
    }

    public bool IsTooLarge(Vector3 desiredSize) {
        return IsTooLarge(desiredSize, false, false, false);
    }

    public bool IsRotatingTooQuickly(Vector3 desiredRotation, bool ignoreX, bool ignoreY, bool ignoreZ)
    {
        bool isRotatingTooQuickly = false;
        if(!ignoreX && currentRotationSpeed.x > desiredRotation.x) 
            isRotatingTooQuickly = true;

        if(!ignoreY && currentRotationSpeed.y > desiredRotation.y) 
            isRotatingTooQuickly = true;

        if(!ignoreZ && currentRotationSpeed.z > desiredRotation.z) 
            isRotatingTooQuickly = true;
        
        return isRotatingTooQuickly;
    }

    public bool IsTooSmall(Vector3 desiredSize, bool ignoreX, bool ignoreY, bool ignoreZ)
    {
        bool isTooSmall = false;
        if(!ignoreX && currentSize.x < desiredSize.x) 
            isTooSmall = true;

        if(!ignoreY && currentSize.y < desiredSize.y) 
            isTooSmall = true;

        if(!ignoreZ && currentSize.z < desiredSize.z) 
            isTooSmall = true;
        
        return isTooSmall;
    }

    public bool IsRotatingTooSlowly(Vector3 desiredRotation, bool ignoreX, bool ignoreY, bool ignoreZ)
    {
        bool isRotatingTooSlowly = false;
        if(!ignoreX && currentRotationSpeed.x < desiredRotation.x) 
            isRotatingTooSlowly = true;

        if(!ignoreY && currentRotationSpeed.y < desiredRotation.y) 
            isRotatingTooSlowly = true;

        if(!ignoreZ && currentRotationSpeed.z < desiredRotation.z) 
            isRotatingTooSlowly = true;
        
        return isRotatingTooSlowly;
    }
}
