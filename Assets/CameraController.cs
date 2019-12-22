using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;

    public float angleDepth;
    public float zoomDistance;
    public float zoomSpeed;
    public float minZoom;
    public float maxZoom;

    public Vector3 pivotPoint;

    void Update()
    {
        Vector3 movementSpeed = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        float rotationalMovement = Input.GetAxisRaw("Rotate");
        float scrollDirection = Input.GetAxis("Mouse ScrollWheel");

        zoomDistance -= scrollDirection * zoomSpeed;
        zoomDistance = Mathf.Clamp(zoomDistance, minZoom, maxZoom);

        transform.Rotate(new Vector3(-angleDepth, 0, 0));
        transform.Translate(movementSpeed * moveSpeed * (zoomDistance / 2) * Time.deltaTime);
        transform.Rotate(new Vector3(angleDepth, 0, 0));

        Ray ray = new Ray(transform.position, transform.forward);
        LayerMask mask = LayerMask.GetMask("Terrain");
        if (Physics.Raycast(ray, out RaycastHit hit, 500, mask))
        {
            pivotPoint = hit.point;
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
