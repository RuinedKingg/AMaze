using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMines : MonoBehaviour
{
    [Header("Scene parameters")]
    [SerializeField] private int sceneIndex;

    void OnEnable()
    {
        TurnOnGeneratorEvent.OnGeneratorOn += ActivateColider;
        Debug.Log("Subscribed event - OnGeneratorOn");
    }

    void OnDisable()
    {
        TurnOnGeneratorEvent.OnGeneratorOn -= ActivateColider;
        Debug.Log("Unsubscribed event - OnGeneratorOn");
    }

    
    void ActivateColider()
    {
        GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(GameObject.Find("UI"));
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
