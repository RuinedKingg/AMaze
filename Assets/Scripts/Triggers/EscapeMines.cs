using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMines : MonoBehaviour
{
    [Header("Scene parameters")]
    [SerializeField] private int sceneIndex;

    void OnEnable()
    {
        TurnOnGeneratorEvent.OnGeneratorOn += ActivateColider;
        Debug.Log("Subscribed event - OnDetonate");
    }

    void OnDisable()
    {
        TurnOnGeneratorEvent.OnGeneratorOn -= ActivateColider;
        Debug.Log("Unsubscribed event - OnDetonate");
    }

    
    void ActivateColider()
    {
        GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
