using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuest: MonoBehaviour
{
    public int Score;
    public List<Quest> quests;
    public Inventory inventory;
    private void Start() {
        inventory = this.gameObject.GetComponent<Inventory>();
    }

    private void Update() {
        foreach(Quest quest in quests){
            quest.questGoal.currentAmount = inventory.GetItemAmount(quest.questGoal.targetType);
        }
    }
}