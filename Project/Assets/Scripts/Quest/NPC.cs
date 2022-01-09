using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public string name;
    public GameObject dialogWindow;

    public Text npcName;
    public Text npcSay;
    public Text firstAnswer;
    public Text secondAnswer;
    public Text thirdAnswer;
    public Button firstButton;
    public Button secondButton;
    public Button thirdButton;

    bool dialogueEnded = false;

    GameObject player;
    public TextAsset ta;

    [SerializeField]
    public int currentNode = 0;
    public int butClicked;
    bool textSet = false;
    Node[] nd;
    private GameObject text;
    Dialogue dialogue;
    private QuestGiver questGiver;
    private List<Quest> playerQuests;
    bool isDialog = false;

    void Start()
    {
        secondButton.enabled = false;
        thirdButton.enabled = false;
        dialogWindow.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        dialogue = Dialogue.Load(ta);
        nd = dialogue.nodes;

        npcSay.text = nd[currentNode].npcText;
        firstAnswer.text = nd[currentNode].answers[currentNode].text;

        firstButton.onClick.AddListener(but1);
        secondButton.onClick.AddListener(but2);
        thirdButton.onClick.AddListener(but3);

        AnswerClicked(-1);

        text = transform.GetChild(3).gameObject;
        npcName.text = name;

        playerQuests = GameObject.Find("UI").GetComponent<PlayerQuest>().quests;
        questGiver = gameObject.GetComponent<QuestGiver>();
    }

    private void Update() {
        if(!isDialog){            
            FindDistance();
        }
        else {
            text.SetActive(false);
        }
    }
    public void OpenDialogWindow(){
        isDialog = true;
        dialogWindow.SetActive(true);
        player.GetComponent<PlayerController>().DisableControl();
        player.GetComponent<PlayerAnimationsChanger>().DisableAnimations();
        player.GetComponent<PlayerSocial>().enabled = false;
    }

    public void CloseDialogWindow(){
        isDialog = false;
        dialogWindow.SetActive(false);
        player.GetComponent<PlayerController>().EnableControl();
        player.GetComponent<PlayerAnimationsChanger>().EnableAnimations();
        player.GetComponent<PlayerSocial>().enabled = true;
    }
    private float FindDistance()
    {
        float distance = 0.3f;
        float curDistance = (transform.position - player.transform.position).sqrMagnitude;
        if (curDistance < distance)
        {
            text.SetActive(true);
        }
        else{
            text.SetActive(false);
        }
        return distance;
    }

    private void but1()
    {
        butClicked = 0;
        AnswerClicked(0);
    }
    private void but2()
    {
        butClicked = 1;
        AnswerClicked(1);
    }
    private void but3()
    {
        butClicked = 2;
        AnswerClicked(2);
    }


    public void AnswerClicked(int numberOfButton)
    {

        if (numberOfButton == -1)
            currentNode = 0;
        else
        {
            if (dialogue.nodes[currentNode].answers[numberOfButton].end == "true")
            {
                CloseDialogWindow();
            }
            Debug.Log(dialogue.nodes[currentNode].answers[numberOfButton].quest);
            if (dialogue.nodes[currentNode].answers[numberOfButton].quest != null)
            {
                int id = dialogue.nodes[currentNode].answers[numberOfButton].quest ?? default(int);
                questGiver.OpenQuestWindow(id);
            }
                
           currentNode = dialogue.nodes[currentNode].answers[numberOfButton].nextNode;
        }
        SetDialog();
    }

    public void SetDialog(){
        Node node = dialogue.nodes[currentNode];
        npcSay.text = node.npcText;

        EditButton(firstButton, firstAnswer, node.answers[0]);
        switch (dialogue.nodes[currentNode].answers.Length)
        {
            case 2:
                EditButton(secondButton, secondAnswer, node.answers[1]);
                thirdButton.enabled = false;
                thirdAnswer.text = "";
                break;
            case 3:
                EditButton(secondButton, secondAnswer, node.answers[1]);
                EditButton(thirdButton, thirdAnswer, node.answers[2]);

                break;
            default:
                secondButton.enabled = false;
                secondAnswer.text = "";
                thirdButton.enabled = false;
                thirdAnswer.text = "";
                break;
        }
    }

    public bool CheckAnswer(Answer answer)
    {
        return (answer.questEnd != null)? true: false;
    }

    public void EditButton(Button btn, Text text, Answer answer)
    {
        if (CheckAnswer(answer))
        {
            Debug.Log(answer.text);
            if (this.gameObject.GetComponent<QuestGiver>().IsQuestCompletable(answer.questEnd ?? default(int)))
            {
                btn.enabled = true;
                btn.onClick.AddListener(() => this.gameObject.GetComponent<QuestGiver>().CompleteQuest(answer.questEnd ?? default(int)));
                text.text = answer.text;
                text.color = Color.green;
            }
            else
            {
                btn.enabled = false;
                text.text = answer.text;
                text.color = Color.red;
            }
        }
        else
        {
            btn.enabled = true;
            text.text = answer.text;
            text.color = Color.black;
        }
    }
}
