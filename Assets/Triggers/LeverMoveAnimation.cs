using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMoveAnimation : MonoBehaviour
{
    [Header("DOTween parametres")]
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private float localZPosition = 0.00382f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetComponent<InventoryComponent>().CheckItem("Lever"))
        {
            transform.DOLocalMoveZ(localZPosition, duration).OnComplete(Exploud);
        }
    }

    private void Exploud()
    {
        Debug.Log("Boom");
    }
}
