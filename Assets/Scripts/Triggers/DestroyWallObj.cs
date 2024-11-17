using UnityEngine;

public class DestroyWallObj : MonoBehaviour
{
    void OnEnable()
    {
        ExplodeEvent.OnDetonate += DestroyObj;
        Debug.Log("Subscribed event - OnDetonate");
    }

    void OnDisable()
    {
        ExplodeEvent.OnDetonate -= DestroyObj;
        Debug.Log("Unsubscribed event - OnDetonate");
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }
}
