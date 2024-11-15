using UnityEngine;

public class EnableObject : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] private GameObject obj;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Collision tag {other.gameObject.tag}");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log($"Player set object {obj.name} active");
            obj.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
