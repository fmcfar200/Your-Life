using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissionManagerScript : MonoBehaviour {

    int currentMission = 0;
    public List<string> missionNames = new List<string>();
    public List<string> missionDescriptions = new List<string>();
    string missionName;
    string missionDesc;

    PlayerInformationScript playerInfo;
    GameObject player;

    string job;


    public GameObject newspaper;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player !=null)
        {
            playerInfo = player.GetComponent<PlayerInformationScript>();
            job = playerInfo.jobs[playerInfo.currentJob];

            if (job == "Unemployed")
            {
                currentMission = 0;
            }

            

        }
    }

    void Update()
    {
        //updates current mission
        missionName = missionNames[currentMission];
        missionDesc = missionDescriptions[currentMission];

        if (currentMission == 0)
        {
            
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
