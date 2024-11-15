using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjectFromInventoryComponent : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] string objectName;

    GameObject obj;

    private void Start()
    {
        obj = gameObject.transform.Find(objectName).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<InventoryComponent>().CheckItem(objectName))
            {
                Debug.Log($"Player set object {obj.name} active");
                obj.SetActive(true);
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
