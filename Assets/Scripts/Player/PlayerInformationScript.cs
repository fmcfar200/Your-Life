using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerInformationScript : MonoBehaviour {

    [Header("Player Stats")]
    public string playerName;
    public int score;
    public float overallWellbeing;
    public List<int> wbStats = new List<int>();
    int totalWellbeing;
    
    [Header("UI Objects")]
    public Text nameText;
    public Text scoreText;
    public Text wellbeingText;
    public List<Image> wbBars = new List<Image>();
    public GameObject wellbeingPanel;

    GameObject controller;
    GameControllerScript gameController;

    bool panelOpen = false;

    void Awake()
    {
        controller = GameObject.Find("GameController");
        if (controller!=null)
        {
            gameController = controller.GetComponent<GameControllerScript>();
            playerName = gameController.playerName;
            score = gameController.playerScore;
            overallWellbeing = gameController.overallWellbeing;

        }
    }

    void Update()
    {
        playerName = gameController.playerName;
        score = gameController.playerScore;
        overallWellbeing = gameController.overallWellbeing;

        nameText.text = playerName;
        scoreText.text = "Score: " + score.ToString();
        wellbeingText.text = "Wellbeing: " + overallWellbeing.ToString("F1");

        for (int i = 0; i < wbStats.Count; i++)
        {
            wbBars[i].fillAmount = (float)wbStats[i] / 10;
        }

        switch(panelOpen)
        {
            case true:
                wellbeingPanel.SetActive(true);
                break;
            case false:
                wellbeingPanel.SetActive(false);
                break;
        }

       

    }

    public void OpenWBPanel()
    {
        if (panelOpen)
        {
            panelOpen = false;
        }
        else
        {
            panelOpen = true;
        }
    }

    void UpdateWellbeing()
    {
        for (int i = 0; i < wbStats.Count; i++)
        {
            totalWellbeing += wbStats[i];
        }

        overallWellbeing = (totalWellbeing / 80) * 100;
    }
}
