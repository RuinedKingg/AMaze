using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class QuestUIComponent : MonoBehaviour
{
    [Header("Quest position parameters")]
    [SerializeField] private Vector3 anchorPosition = Vector3.zero;
    [SerializeField] private float positionOffset = 0f;

    [Header("Text prefab parameters")]
    [SerializeField] private TextMeshProUGUI textPrefab;

    private Dictionary<string, TextMeshProUGUI>  questDict = new Dictionary<string, TextMeshProUGUI>();

    private void Start()
    {
        TriggerQuestAdd("QuitQuest", "Find a way out of the mines");
    }

    [ContextMenu("Add quest")]
    void OnAddQuestTest()
    {
        var number = questDict.Count;
        Debug.Log(number);
        TriggerQuestAdd($"TestName{number}", "Test");
    }

    [ContextMenu("Complete quest")]
    void OnCompleteQuestTest()
    {
        var number = questDict.Count - 1;
        Debug.Log(number);
        TriggerQuestComplete($"TestName{number}");
    }

    [ContextMenu("Clear dict")]
    void OnClearDict()
    {
        questDict.Clear();
    }

    public void TriggerQuestAdd(string questName, string questText)
    {
        if(!questDict.ContainsKey(questName))
        {
            TextMeshProUGUI quest = Instantiate(textPrefab, Vector3.zero, Quaternion.identity, gameObject.transform);

            quest.text = questText;
            quest.rectTransform.anchorMax = new Vector2(0, 1);
            quest.rectTransform.anchorMin = new Vector2(0, 1);
            var objPosition = anchorPosition;
            objPosition.y = objPosition.y + (positionOffset * questDict.Count);
            quest.rectTransform.anchoredPosition = objPosition;

            questDict.Add(questName, quest);
        }
    }

    public void TriggerQuestComplete(string questName)
    {
        if (questDict.ContainsKey(questName))
        {
            var quest = questDict[questName];

            questDict.Remove(questName);
            Destroy(quest.gameObject);

            ShiftQuests();
        }
    }

    private void ShiftQuests()
    {
        var questPosition = 0;

        foreach(var quest in questDict.Values)
        {
            var objPosition = anchorPosition;
            objPosition.y = objPosition.y + (positionOffset * questPosition);
            quest.rectTransform.anchoredPosition = objPosition;

            questPosition++;
        }
    }
}
