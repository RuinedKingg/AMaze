using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCompleteQuest : MonoBehaviour
{
    [Header("Quest parameters")]
    [SerializeField] private string questName;
    [SerializeField] private GameObject addQuestObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("UI").GetComponent<QuestUIComponent>().TriggerQuestComplete(questName);
            if (addQuestObj != null)
            {
                addQuestObj.SetActive(false);
            }
            gameObject.SetActive(false);
        }
    }
}
