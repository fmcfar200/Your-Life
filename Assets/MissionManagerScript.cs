using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MissionManagerScript : MonoBehaviour {

    //Mission vars
    int currentMission = 0;
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

    //job
    string job;

    //objects
    public GameObject newspaper;

    //UI
    public GameObject workButton;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timeManager = GameObject.Find("TimeManager");
        if (player !=null)
        {
            playerInfo = player.GetComponent<PlayerInformationScript>();
            job = playerInfo.jobs[playerInfo.currentJob];

            if (job == "Unemployed")
            {
                currentMission = 0;
            }

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


        if (job != "Unemployed")
        {
            if (timeScript.currentDay > 0 && timeScript.currentDay < 6 )
            {
                if (timeScript.hour >= 9 && timeScript.hour <= 12)
                {
                    workButton.SetActive(true);
                }
                else
                {
                    workButton.SetActive(false);

                }

            }
        }
        else
        {
            workButton.SetActive(false);
        }

        
    }

    public void GetNewJob()
    {
        playerInfo.currentJob++;
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
