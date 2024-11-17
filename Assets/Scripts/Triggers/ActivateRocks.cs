using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRocks : MonoBehaviour
{
    [Header("Explosion parametres")]
    [SerializeField] private float explosionForce = 1.0f;
    [SerializeField] private float explosionRadius = 1.0f;
    [SerializeField] private Vector3 exploisionPosition = Vector3.zero;

    private Rigidbody body;

    void OnEnable()
    {
        ExplodeEvent.OnDetonate += Activate;
        Debug.Log("Subscribed event - OnDetonate");

        body = GetComponent<Rigidbody>();
    }

    void OnDisable()
    {
        ExplodeEvent.OnDetonate -= Activate;
        Debug.Log("Unsubscribed event - OnDetonate");
    }


    void Activate()
    {
        body.constraints = RigidbodyConstraints.None;
        body.AddExplosionForce(explosionForce, exploisionPosition, explosionRadius);
    }
}
