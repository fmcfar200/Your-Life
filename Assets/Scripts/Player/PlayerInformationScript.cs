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
    public Dictionary<string, int> wbDiction = new Dictionary<string, int>();

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

        wbDiction.Add("Safe", wbStats[0]);
        wbDiction.Add("Healthy", wbStats[1]);
        wbDiction.Add("Active", wbStats[2]);
        wbDiction.Add("N", wbStats[3]);
        wbDiction.Add("Accepted", wbStats[4]);
        wbDiction.Add("Respected", wbStats[5]);
        wbDiction.Add("Responsible", wbStats[6]);
        wbDiction.Add("Included", wbStats[7]);

        UpdateWellbeing();



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

        overallWellbeing = (float) (totalWellbeing / 8) * 100;
        Debug.Log(overallWellbeing.ToString("F1") + " "+totalWellbeing);
    }
}
