using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMove : MonoBehaviour
{
    public Rigidbody body;
    public float speed;
    public float acceleration;

    public float currentSpeed = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            currentSpeed += speed * acceleration * Time.deltaTime;
            if(currentSpeed > speed)
            {
                currentSpeed = speed;
            }
        }
        else
        {
            currentSpeed -= speed * acceleration * Time.deltaTime;
            if (currentSpeed < 0f)
            {
                currentSpeed = 0f;
            }
        }

        // Cast a ray from screen point
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // You successfully hit
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Find the direction to move in
            Vector3 dir = (hit.point - transform.position).normalized;

            // Make it so that its only in x and y axis
            dir.y = 0; // No vertical movement

            // Now move your character in world space 
            body.MovePosition(transform.position + dir * Time.deltaTime * currentSpeed);
            //transform.Translate(dir * Time.deltaTime * currentSpeed, Space.World);
        }
    }
}
