using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMines : MonoBehaviour
{
    [Header("Scene parametre")]
    [SerializeField] private int sceneIndex = 0;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(SceneManager.GetSceneByBuildIndex(sceneIndex).name);

        if (other.CompareTag("Player") && SceneManager.GetSceneByBuildIndex(sceneIndex).buildIndex != -1)
        {
            SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
        }
    }
}
