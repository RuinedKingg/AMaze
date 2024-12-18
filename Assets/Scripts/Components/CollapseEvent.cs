using UnityEngine;

public class CollapseEvent : MonoBehaviour
{
    public delegate void CollapseEventHandler();
    public static event CollapseEventHandler OnRocksCollapse;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Collision tag {other.gameObject.tag}");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log($"Player trigger collapse event");
            OnRocksCollapse?.Invoke();
        }
    }
}
