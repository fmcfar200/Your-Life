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

    float totalWellbeing;
    
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



        UpdateWellbeing();  


    }

    void Update()
    {
        playerName = gameController.playerName;
        score = gameController.playerScore;

        wbStats[0] = gameController.safe;
        wbStats[1] = gameController.healthy;
        wbStats[2] = gameController.active;
        wbStats[3] = gameController.nurtured;
        wbStats[4] = gameController.accepted;
        wbStats[5] = gameController.respected;
        wbStats[6] = gameController.responsible;
        wbStats[7] = gameController.included;


        nameText.text = playerName;
        scoreText.text = "Score: " + score.ToString();
        wellbeingText.text = "Wellbeing: " + overallWellbeing.ToString("F1") + "%";



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

        overallWellbeing =(totalWellbeing / 80) * 100;
        Debug.Log(overallWellbeing.ToString() + " "+totalWellbeing);
    }
}
