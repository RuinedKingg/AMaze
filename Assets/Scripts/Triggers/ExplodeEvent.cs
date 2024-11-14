using DG.Tweening;
using UnityEngine;

public class ExplodeEvent : MonoBehaviour
{
    [Header("DOTween parametres")]
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private float localZPosition = 0.00382f;

    private bool isReady = false;
    private string tagName = "Tnt";

    public delegate void DetonateHandler();
    public static event DetonateHandler OnDetonate;

    void OnEnable()
    {
        SetupTntEvent.OnTntPlaced += SetReadyTrue;
    }

    void OnDisable()
    {
        SetupTntEvent.OnTntPlaced -= SetReadyTrue;
    }

    private void Start()
    {
        isReady = GameObject.FindGameObjectWithTag(tagName).activeInHierarchy;
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
        isReady = true;
    }
}
