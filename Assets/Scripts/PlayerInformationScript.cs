using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInformationScript : MonoBehaviour {

    [Header("Player Stats")]
    public string playerName;
    public string[] jobs = {"Unemployed","Paperboy","Delivery","Plumber"};
    public int currentJob;
    public int cash;

    [Header("UI Objects")]
    public Text nameText;
    public Text jobText;
    public Text cashText;
    

    void Start()
    {
        //TEMP
        playerName = "Scott";
        currentJob = 0;
        cash = 50;
    }

    void Update()
    {
        nameText.text = playerName;
        jobText.text = jobs[currentJob];
        cashText.text = "£" + cash.ToString();
    }
}
