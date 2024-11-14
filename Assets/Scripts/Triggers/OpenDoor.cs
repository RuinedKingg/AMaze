using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [Header("DOTween parametres")]
    [SerializeField] private float duration = 1f;
    [SerializeField] private Vector3 localRotationVector3 = Vector3.zero;

    private void OnTriggerEnter(Collider other)
    {
        var collidedBody = other.gameObject;

        if (collidedBody.CompareTag("Player"))
        {
            if (collidedBody.GetComponent<InventoryComponent>().CheckItem("Key"))
            {
                transform.DOLocalRotate(localRotationVector3, duration);
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
