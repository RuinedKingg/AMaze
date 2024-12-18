using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAddQuest : MonoBehaviour
{
    [Header("Quest parameters")]
    [SerializeField] private string questText;
    [SerializeField] private string questName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("UI").GetComponent<QuestUIComponent>().TriggerQuestAdd(questName, questText);
            gameObject.SetActive(false);
        }
    }
}
