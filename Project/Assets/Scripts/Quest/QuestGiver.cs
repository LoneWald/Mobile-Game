using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public List<Quest> quests;
    public PlayerQuest playerQuests;
    public Inventory inventory;
    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;
    public Text rewardText;

    private void Start() {
        questWindow.SetActive(false);
    }

    public void OpenQuestWindow(int id){
        int questId = quests.FindIndex(x => x.id == id);
        questWindow.SetActive(true);
        titleText.text = quests[questId].title;
        descriptionText.text = quests[questId].description;
        rewardText.text = "Награда: " + quests[questId].reward.ToString() + " очков";
        if(playerQuests.quests.IndexOf(quests[questId])==-1){
            AcceptQuest(questId); // Автопринятие квеста
        }
    }

    public void CloseQuestWindow(){
        questWindow.SetActive(false);
    }
    
    public void AcceptQuest(int id){
        quests[id].isActive = true;
        playerQuests.quests.Add(quests[id]);
    }

    public void DeclineQuest()
    {
        questWindow.SetActive(false);
    }

    public bool IsQuestCompletable(int id)
    {
        int questId = quests.FindIndex(x => x.id == id);
        if (questId >= 0)
        {
            if (quests[questId].questGoal.goalType == GoalType.Gathering)
            {
                if (inventory.GetItemAmount(quests[questId].questGoal.targetType) >= quests[questId].questGoal.requiredAmount)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void CompleteQuest(int id){
        int questId = quests.FindIndex(x => x.id == id);
        if(questId >= 0){
        if (quests[questId].questGoal.goalType == GoalType.Gathering)
        {
            if (inventory.GetItemAmount(quests[questId].questGoal.targetType) >= quests[questId].questGoal.requiredAmount)
            {
                quests[questId].isComplete = true;
                playerQuests.quests[quests.FindIndex(x => x.id == id)].isComplete = true;
                playerQuests.quests[quests.FindIndex(x => x.id == id)].isActive = false;
            }
        }
        }
    }
}
