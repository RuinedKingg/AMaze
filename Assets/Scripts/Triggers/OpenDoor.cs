using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [Header("DOTween parameters")]
    [SerializeField] private float duration = 1f;
    [SerializeField] private Vector3 rotationVector3 = Vector3.zero;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<InventoryComponent>().CheckItem("Key"))
        {
            transform.DORotate(rotationVector3, duration);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
