using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;

    public float zoomDistance;
    public float zoomSpeed;
    public float minZoom;
    public float maxZoom;

    public Vector3 pivotPoint;
    public Transform listener;

    void Update()
    {
        float forwardMovement = Input.GetAxisRaw("Vertical");
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float rotationalMovement = Input.GetAxisRaw("Rotate");
        float scrollDirection = Input.GetAxis("Mouse ScrollWheel");

        zoomDistance -= scrollDirection * zoomSpeed * Time.deltaTime;
        zoomDistance = Mathf.Clamp(zoomDistance, minZoom, maxZoom);

        transform.Rotate(new Vector3(-45, 0, 0));
        transform.Translate(new Vector3(horizontalMovement * moveSpeed * Time.deltaTime, 0, forwardMovement * moveSpeed * Time.deltaTime));
        transform.Rotate(new Vector3(45, 0, 0));

        Ray ray = new Ray(transform.position, transform.forward);
        LayerMask mask = LayerMask.GetMask("Ground");
        if (Physics.Raycast(ray, out RaycastHit hit, 500, mask))
        {
            pivotPoint = hit.point;
            listener.position = hit.point;
            transform.position = hit.point;
            transform.Translate(new Vector3(0, 0, -zoomDistance));
        }

        transform.RotateAround(pivotPoint, Vector3.up, rotationalMovement * rotateSpeed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(pivotPoint, 1);
    }
}
