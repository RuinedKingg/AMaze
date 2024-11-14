using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnCollider : MonoBehaviour
{
    [Header("Object parameters")]
    [SerializeField] private string objName;

    private GameObject obj;

    private void Start()
    {
        var interactableObjects = GameObject.FindGameObjectsWithTag("Interactable");
        GameObject obj;

        foreach (var item in interactableObjects)
        {
            obj = item.name == objName ? item : null;

            if (obj != null) break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && obj != null)
        {
            obj.GetComponent<BoxCollider>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
