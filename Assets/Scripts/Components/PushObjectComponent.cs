using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObjectComponent : MonoBehaviour
{
    [SerializeField] private float pushForce = 1.0f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if (rb != null && !rb.isKinematic)
        {
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            rb.velocity = pushDir * pushForce;
        }
    }
}
