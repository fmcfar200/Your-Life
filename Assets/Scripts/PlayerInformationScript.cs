using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInformationScript : MonoBehaviour {

    [Header("Player Stats")]
    public string playerName;
    public string job;
    public int cash;

    [Header("UI Objects")]
    public Text nameText;
    public Text jobText;
    public Text cashText;
    

    void Start()
    {
        //TEMP
        playerName = "Scott";
        job = "Unemployed";
        cash = 50;
    }

    void Update()
    {
        nameText.text = playerName;
        jobText.text = job;
        cashText.text = "£" + cash.ToString();
    }
}
