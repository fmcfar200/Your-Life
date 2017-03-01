using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

    public static GameControllerScript controller;

    //playerdata
    public string playerName;
    public int playerScore;
    public float overallWellbeing;

    //time data
    public int day;
    public int hour;

    //scripts
    PlayerInformationScript playerInfo;
    MissionManagerScript missionManager;
    TimeCycleScript timeScript;

    //gameobjects

    GameObject playerObj;
    GameObject timeManagerObj;
    GameObject missionManagerObj;
    Button saveButton;
    Button loadButton;




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
        if (Application.loadedLevelName == "HomeScene")
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
            timeManagerObj = GameObject.Find("TimeManager");

            if (playerObj != null)
            {
                playerInfo = playerObj.GetComponent<PlayerInformationScript>();

                playerName = playerInfo.playerName;
                playerScore = playerInfo.score;
                overallWellbeing = playerInfo.overallWellbeing;

            }
            else
            {
                Debug.LogError(playerObj.name + " not found!!");
            }

            if (timeManagerObj != null)
            {
                timeScript = timeManagerObj.GetComponent<TimeCycleScript>();
            }
            else
            {
                Debug.LogError(timeManagerObj.name + " not found!!");
            }

            saveButton = GameObject.Find("SaveButton").GetComponent<Button>();
            loadButton = GameObject.Find("LoadButton").GetComponent<Button>();

            saveButton.onClick.AddListener(() => Save());
            loadButton.onClick.AddListener(() => Load());
        }
    }

    void Update()
    {
        //TEMP TO QUIT
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            
        }

      
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
