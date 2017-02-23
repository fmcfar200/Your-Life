using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class GameControllerScript : MonoBehaviour {

    public static GameControllerScript controller;

    //playerdata
    public string playerName;
    public int playerScore;
    public float overallWellbeing;

    //time data
    int day;
    int hour;

    //scripts
    PlayerInformationScript playerInfo;
    MissionManagerScript missionManager;
    TimeCycleScript timeScript;

    //gameobjects

    GameObject playerObj;
    GameObject timeManagerObj;
    GameObject missionManagerObj;


    void Awake()
    {
        if (controller == null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        timeManagerObj = GameObject.Find("TimeManager");

        if (playerObj != null)
        {
            playerInfo = playerObj.GetComponent<PlayerInformationScript>();

            playerName = playerInfo.playerName;
            playerScore = playerInfo.score;
        }
        else
        {
            Debug.LogError(playerObj.name + " not found!!");
        }

        if (timeManagerObj != null)
        {
            timeScript = timeManagerObj.GetComponent<TimeCycleScript>();

            day = timeScript.currentDay;
            hour = timeScript.hour;
        }
        else
        {
            Debug.LogError(timeManagerObj.name + " not found!!");
        }

        playerName = "Scott";
        playerScore = 0;
        overallWellbeing = 65.0f;
    }

    void Update()
    {
        UpdatePlayerData();
        UpdateTimeData();
    }

    void UpdatePlayerData()
    {
        playerName = playerInfo.playerName;
        playerScore = playerInfo.score;
    }

    void UpdateTimeData()
    {
        day = timeScript.currentDay;
        hour = timeScript.hour;
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerData.dat");

        PlayerData playerData = new PlayerData();
        playerData.name = playerName;
        playerData.score = playerScore;
        playerData.overallWellbeing = overallWellbeing;

        bf.Serialize(file, playerData);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerdata.dat",FileMode.Open);
            PlayerData playerData = (PlayerData)bf.Deserialize(file);
            file.Close();

            playerName = playerData.name;
            playerScore = playerData.score;
            overallWellbeing = playerData.overallWellbeing;

            Debug.Log(playerName+" " +playerScore.ToString() + " " + overallWellbeing.ToString("F1"));

        }
                
    }

    //class for saving purposes
    [Serializable]
    class PlayerData
    {
        public string name;
        public int score;
        public float overallWellbeing;
    }
}
