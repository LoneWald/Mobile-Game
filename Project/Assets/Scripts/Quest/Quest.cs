using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;
    public bool isComplete = false;

    public int id;
    public string title;
    public string description;
    public int reward;

    public QuestGoal questGoal;
}
