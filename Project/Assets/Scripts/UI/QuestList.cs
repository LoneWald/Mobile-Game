using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestList : MonoBehaviour
{
    public PlayerQuest player;
    public Transform parent;
    public GameObject pref;

    public void UpdateList()
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Destroy(parent.GetChild(i).gameObject);
        }
        foreach (Quest quest in player.quests)
        {
            SetPref(pref, quest);
            if (quest.isComplete)
            {
                pref.transform.GetChild(1).GetComponent<Text>().text = "Завершено";
            }
            GameObject.Instantiate(pref, parent);
        }
    }

    public void SetPref(GameObject pref, Quest quest)
    {
        pref.transform.GetChild(0).GetComponent<Text>().text = quest.title;
        pref.transform.GetChild(2).GetComponent<Text>().text = quest.description;
        switch (quest.questGoal.goalType)
        {
            case GoalType.Gathering:
                pref.transform.GetChild(1).GetComponent<Text>().text = "Собрано " + quest.questGoal.currentAmount + "/" + quest.questGoal.requiredAmount;
                break;
            case GoalType.Kill:
                pref.transform.GetChild(1).GetComponent<Text>().text = "Убито " + quest.questGoal.currentAmount + "/" + quest.questGoal.requiredAmount;
                break;
            case GoalType.Other:
                pref.transform.GetChild(1).GetComponent<Text>().text = "";
                break;
            default:
                pref.transform.GetChild(1).GetComponent<Text>().text = "";
                break;
        }
    }

    private void Update()
    {
        UpdateList();
    }
}