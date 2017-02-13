using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissionManagerScript : MonoBehaviour {

    int currentMission = 0;
    public List<string> missionNames = new List<string>();
    public List<string> missionDescriptions = new List<string>();

    string GetMissionName()
    {
        return missionNames[currentMission];
    }
    string GetMissionDesc()
    {
        return missionDescriptions[currentMission];
    }

   
}
