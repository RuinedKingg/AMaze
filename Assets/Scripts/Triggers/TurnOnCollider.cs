using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnCollider : MonoBehaviour
{
    [Header("Object parameters")]
    [SerializeField] private string objName;

    private GameObject Obj;

    private void Start()
    {
        var interactableObjects = GameObject.FindGameObjectsWithTag("Interactable");

        foreach (var item in interactableObjects)
        {
            Obj = item.name == objName ? item : null;

            if (Obj != null) break;
        }

        Debug.Log($"Obj - {Obj.name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Obj != null)
        {
            Obj.GetComponent<BoxCollider>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
