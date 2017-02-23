using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class GameControllerScript : MonoBehaviour {

    public static GameControllerScript controller;

    //playerdata
    string playerName;
    string playerJob;
    int playerCash;

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
            playerJob = playerInfo.jobs[playerInfo.currentJob];
            playerCash = playerInfo.cash;
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
    }

    void Update()
    {
        UpdatePlayerData();
        UpdateTimeData();
    }

    void UpdatePlayerData()
    {
        playerName = playerInfo.playerName;
        playerJob = playerInfo.jobs[playerInfo.currentJob];
        playerCash = playerInfo.cash;
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
        playerData.job = playerJob;
        playerData.cash = playerCash;

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
            playerJob = playerData.job;
            playerCash = playerData.cash;

            Debug.Log(playerName+" "+ playerJob+" " +playerCash.ToString());

        }
                
    }

    //class for saving purposes
    [Serializable]
    class PlayerData
    {
        public string name;
        public string job;
        public int cash;
    }
}
