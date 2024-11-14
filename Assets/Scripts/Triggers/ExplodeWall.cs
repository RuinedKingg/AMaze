using UnityEngine;

public class ExplodeWall : MonoBehaviour
{
    void OnEnable()
    {
        ExplodeEvent.OnDetonate += Explode;
    }

    void OnDisable()
    {
        ExplodeEvent.OnDetonate -= Explode;
    }

    void Explode()
    {
        Debug.Log("Wall with TNT exploded!");
        Destroy(gameObject);
    }
}
