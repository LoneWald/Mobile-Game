using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public InputActions input;
    public Button _menu;
    public GameObject questList;
    private void Awake()
    {
        input = new InputActions();
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
    void Start()
    {
        Cursor.visible = true;
        questList.SetActive(false);
    }
    void Update()
    {
        if(input.UIInput.ShowQuests.triggered){
            questList.SetActive(!questList.activeSelf);
            //questList.GetComponent<QuestList>().UpdateList();
        }
    }
    public void NewGame()
    {
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Manual()
    {
        SceneManager.LoadScene(3);
    }
}