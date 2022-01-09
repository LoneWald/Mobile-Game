using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;
    public int targetType;
    public int requiredAmount;
    public int currentAmount;

    public bool IsReached(){
        return (currentAmount >= requiredAmount);
    }
    
    public void ItemGatchered(){
        if(goalType == GoalType.Gathering){
            currentAmount++;
        }
    }

    public void EnemyKilled(){
        if(goalType == GoalType.Kill){
            currentAmount++;
        }
    }
}

public enum GoalType{
    Kill, 
    Gathering, 
    Other
}
