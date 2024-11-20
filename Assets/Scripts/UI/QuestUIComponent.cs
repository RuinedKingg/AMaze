using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class QuestUIComponent : MonoBehaviour
{
    [Header("Quest position parameters")]
    [SerializeField] private Vector3 anchorPosition = Vector3.zero;
    [SerializeField] private float positionOffset = 0f;

    private List<TextMeshProUGUI> questList;

    [ContextMenu("Add quest")]
    void OnAddQuestTest()
    {
        TriggerQuestAdd("Test");
    }

    public void TriggerQuestAdd(string questText)
    {
        var quest = new TextMeshProUGUI();

        quest.text = questText;
        quest.rectTransform.anchorMax = new Vector2(0, 1);
        quest.rectTransform.anchorMin = new Vector2(0, 1);
        anchorPosition.y = anchorPosition.y + (positionOffset * questList.Count);
        quest.rectTransform.anchoredPosition = anchorPosition;

        questList.Add(quest);
    }

    public void TriggerQuestComplete()
    {
        return;
    }
}
