using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MissionManagerScript : MonoBehaviour {

    //Mission vars
    public int currentMission = 0;
    public List<string> missionNames = new List<string>();
    public List<string> missionDescriptions = new List<string>();
    string missionName;
    string missionDesc;

    //player info and player obj
    PlayerInformationScript playerInfo;
    GameObject player;

    //time script and manager
    TimeCycleScript timeScript;
    GameObject timeManager;

    //objects
    public GameObject newspaper;

    //UI
    public GameObject workButton;
    public Text missionNameTextQuick;
    public Text missionNameText;
    public Text missionDescText;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timeManager = GameObject.Find("TimeManager");
        if (player !=null)
        {
            playerInfo = player.GetComponent<PlayerInformationScript>();
        }
        else
        {
            Debug.LogError("PLAYER NOT FOUND");
        }

        if (timeManager!=null)
        {
            timeScript = timeManager.GetComponent<TimeCycleScript>();
        }
        else
        {
            Debug.LogError("Cant find time");
        }

    }

    void Update()
    {
        //updates current mission
        missionName = missionNames[currentMission];
        missionDesc = missionDescriptions[currentMission];

        //updates mission UI
        missionNameText.text = missionName;
        missionNameTextQuick.text = missionName;
        missionDescText.text = missionDesc;
        
    }

    public void LoadMinigameLevel(string gameName)
    {
        if (gameName == "BikeRide")
        {
            Application.LoadLevel("BikeRide");
        }
    }


    string GetMissionName()
    {
        return missionNames[currentMission];
    }
    string GetMissionDesc()
    {
        return missionDescriptions[currentMission];
    }

   
}
