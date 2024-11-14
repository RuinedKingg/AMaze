using UnityEngine;

public class SetupTntEvent : MonoBehaviour
{
    public delegate void PlaceTntHandler();
    public static event PlaceTntHandler OnTntPlaced;

    // Start is called before the first frame update
    void Start()
    {
        OnTntPlaced?.Invoke();
    }
}
