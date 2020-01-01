using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRadius : MonoBehaviour
{
    public float radius = 1f;
    public Vector3 offset;

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + offset, radius);
        foreach(Collider hitCollider in hitColliders)
        {
            IPickupable pickup = hitCollider.GetComponent<IPickupable>();
            if(pickup != null && pickup.IsActive)
            {
                pickup.Pickup(gameObject);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + offset, radius);
    }
}
