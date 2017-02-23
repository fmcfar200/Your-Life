using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInformationScript : MonoBehaviour {

    [Header("Player Stats")]
    public string playerName;
    public int score;
    public float overallWellbeing;

    [Header("UI Objects")]
    public Text nameText;
    public Text scoreText;
    public Text wellbeingText;

    GameObject controller;
    GameControllerScript gameController;

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

        nameText.text = gameController.playerName;
        scoreText.text = "Score: " + gameController.playerScore.ToString();
        wellbeingText.text = "Wellbeing: " + gameController.overallWellbeing.ToString("F1");
    }
}
