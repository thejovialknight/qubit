using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationHelper
{
    public static void ScaleTowards(Transform transform, Vector3 scale, float speed, bool ignoreX, bool ignoreY, bool ignoreZ)
    {
        Vector3 currentSize = transform.localScale;
        float xChange = Mathf.Sign(currentSize.x - scale.x);
        float yChange = Mathf.Sign(currentSize.y - scale.y);
        float zChange = Mathf.Sign(currentSize.z - scale.z);

        if(!ignoreX) 
        {
            if(currentSize.x < scale.x)
                currentSize.x += speed * Time.deltaTime;
            else if(currentSize.x > scale.x)
                currentSize.x -= speed * Time.deltaTime;
        }

        if(!ignoreY) 
        {
            if(currentSize.y < scale.y)
                currentSize.y += speed * Time.deltaTime;
            else if(currentSize.y > scale.y)
                currentSize.y -= speed * Time.deltaTime;
        }

        if(!ignoreZ)
        {
            if(currentSize.z < scale.z)
                currentSize.z += speed * Time.deltaTime;
            else if(currentSize.z > scale.z)
                currentSize.z -= speed * Time.deltaTime;
        }

        if(xChange != Mathf.Sign(currentSize.x - scale.x))
            currentSize.x = scale.x;

        if(yChange != Mathf.Sign(currentSize.y - scale.y))
            currentSize.y = scale.y;

        if(zChange != Mathf.Sign(currentSize.z - scale.z))
            currentSize.z = scale.z;

        transform.localScale = currentSize;
    }

    public static void ScaleTowards(Transform transform, Vector3 scale, float speed) 
    {
        ScaleTowards(transform, scale, speed, false, false, false);
    }

    public static void AccelerateRotationTowards(Rotator rotator, Vector3 rotation, float speed, bool ignoreX, bool ignoreY, bool ignoreZ)
    {
        Vector3 currentRotationSpeed = rotator.speed;
        float xChange = Mathf.Sign(currentRotationSpeed.x - rotation.x);
        float yChange = Mathf.Sign(currentRotationSpeed.y - rotation.y);
        float zChange = Mathf.Sign(currentRotationSpeed.z - rotation.z);

        if(!ignoreX)
        { 
            if (currentRotationSpeed.x < rotation.x)
                currentRotationSpeed.x += speed * rotation.x * Time.deltaTime;
            else if (currentRotationSpeed.x > rotation.x)
                currentRotationSpeed.x -= speed * rotation.x * Time.deltaTime;
        }

        if(!ignoreY) 
        {
            if (currentRotationSpeed.y < rotation.y)
                currentRotationSpeed.y += speed * rotation.y * Time.deltaTime;
            else if (currentRotationSpeed.y > rotation.y)
                currentRotationSpeed.y -= speed * rotation.y * Time.deltaTime;
        }

        if(!ignoreZ) 
        {
            if (currentRotationSpeed.z < rotation.z)
                currentRotationSpeed.z += speed * rotation.z * Time.deltaTime;
            else if (currentRotationSpeed.z > rotation.z)
                currentRotationSpeed.z -= speed * rotation.z * Time.deltaTime;
        }

        if(xChange != Mathf.Sign(currentRotationSpeed.x - rotation.x))
            currentRotationSpeed.x = rotation.x;

        if(yChange != Mathf.Sign(currentRotationSpeed.y - rotation.y))
            currentRotationSpeed.y = rotation.y;

        if(zChange != Mathf.Sign(currentRotationSpeed.z - rotation.z))
            currentRotationSpeed.z = rotation.z;

        rotator.speed = currentRotationSpeed;
    }

    public static void AccelerateRotationTowards(Rotator rotator, Vector3 rotation, float speed) 
    {
        AccelerateRotationTowards(rotator, rotation, speed, false, false, false);
    }

    public static bool CheckSize(Transform transform, Vector3 scale, bool ignoreX, bool ignoreY, bool ignoreZ) {
        bool isRightSize = true;
        if(!ignoreX && transform.localScale.x != scale.x) 
            isRightSize = false;

        if(!ignoreY && transform.localScale.y != scale.y) 
            isRightSize = false;

        if(!ignoreZ && transform.localScale.z != scale.z) 
            isRightSize = false;
        
        return isRightSize;
    }

    public static bool CheckRotation(Rotator rotator, Vector3 rotation, bool ignoreX, bool ignoreY, bool ignoreZ) {
        bool isCorrectRotation = true;
        if(!ignoreX && rotator.speed.x != rotation.x) 
            isCorrectRotation = false;

        if(!ignoreY && rotator.speed.y != rotation.y) 
            isCorrectRotation = false;

        if(!ignoreZ && rotator.speed.z != rotation.z) 
            isCorrectRotation = false;
        
        return isCorrectRotation;
    }
}
