using UnityEngine;

public class ExplodeWall : MonoBehaviour
{
    [SerializeField] private RigidbodyConstraints bodyConstraints;

    void OnEnable()
    {
        ExplodeEvent.OnDetonate += Explode;
        Debug.Log("Subscribed event - OnDetonate");
    }

    void OnDisable()
    {
        ExplodeEvent.OnDetonate -= Explode;
        Debug.Log("Unsubscribed event - OnDetonate");
    }

    void Explode()
    {
        Destroy(GameObject.Find("RockWall"));
        Destroy(GameObject.FindGameObjectWithTag("Tnt"));

        var bodys = GameObject.Find("BodyRock").GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody body in bodys)
        {
            body.constraints = bodyConstraints;
        }
    }
}
