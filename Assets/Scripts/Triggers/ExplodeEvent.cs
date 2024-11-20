using DG.Tweening;
using UnityEngine;

public class ExplodeEvent : MonoBehaviour
{
    [Header("DOTween parameters")]
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private float localZPosition = 0.00382f;

    private bool isReady = false;
    private string tagName = "Tnt";

    public delegate void DetonateHandler();
    public static event DetonateHandler OnDetonate;

    void OnEnable()
    {
        SetupTntEvent.OnTntPlaced += SetReadyTrue;
        Debug.Log("Subscribed event - OnTntPlaced");
    }

    void OnDisable()
    {
        SetupTntEvent.OnTntPlaced -= SetReadyTrue;
        Debug.Log("Unsubscribed event - OnTntPlaced");
    }

    private void Start()
    {
        var tntObj = GameObject.FindGameObjectWithTag(tagName);
        isReady = tntObj != null && tntObj.activeInHierarchy;
        Debug.Log($"Is detonator ready: {isReady}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isReady)
        {
            transform.DOLocalMoveZ(localZPosition, duration).OnComplete(Exploud);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void Exploud()
    {
        Debug.Log("Boom");
        OnDetonate?.Invoke();
    }

    private void SetReadyTrue()
    {
        Debug.Log("Detonator ready");
        isReady = true;
    }
}
