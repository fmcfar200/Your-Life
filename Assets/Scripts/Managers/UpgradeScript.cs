using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour {

    //GO and Buttons
    GameObject upgradeMenu;

    [Header("Bike Buttons")]
    public List<Button> bikeUpgradeButtons = new List<Button>();
    [Header("Car Buttons")]
    public List<Button> carUpgradeButtons = new List<Button>();

    [Header("Bike Objects")]
    public List<GameObject> bikes = new List<GameObject>();

    GameObject gameControllerObj;
    GameControllerScript gameController;

    public Text costTextBike;

    
    int bikeTier;
    int carTier;


    int score;
    int bikeCost;
    int carCost;

    bool bikeSpawned;

    void Awake()
    {
        if(Application.loadedLevelName == "HomeScene")
        {
            upgradeMenu = GameObject.Find("Upgrade_Menu");
            bikeUpgradeButtons.Add(GameObject.Find("Bike_UG_Button_1").GetComponent<Button>());
            bikeUpgradeButtons.Add(GameObject.Find("Bike_UG_Button_2").GetComponent<Button>());
            bikeUpgradeButtons.Add(GameObject.Find("Bike_UG_Button_3").GetComponent<Button>());

            carUpgradeButtons.Add(GameObject.Find("Car_UG_Button_1").GetComponent<Button>());
            carUpgradeButtons.Add(GameObject.Find("Car_UG_Button_2").GetComponent<Button>());
            carUpgradeButtons.Add(GameObject.Find("Car_UG_Button_3").GetComponent<Button>());

           
        }

        gameControllerObj = GameObject.Find("GameController");
        if (gameControllerObj !=null)
        {
            gameController = gameControllerObj.GetComponent<GameControllerScript>();
            bikeTier = gameController.bikeTier;
            carTier = gameController.carTier;
        }
        else
        {
            Debug.LogError("cant find controller");
        }
        upgradeMenu.SetActive(false);
        
        foreach(GameObject bike in bikes)
        {
            bike.SetActive(false);
        }

    }

    void Start()
    {
       
        foreach(Button button in bikeUpgradeButtons)
        {
            button.onClick.AddListener(() => UpgradeBike());
            button.interactable = false;
        }


        

    }

    void Update()
    {
        score = gameController.playerScore;

        bikes[bikeTier].SetActive(true);
        switch(bikeTier)
        {
            case 0:

                bikeUpgradeButtons[0].interactable = true;
                bikeCost = 2000;

                break;
            case 1:
                bikes[bikeTier - 1].SetActive(false);
                bikeUpgradeButtons[0].interactable = true;
                bikeUpgradeButtons[1].interactable = true;
                bikeCost = 4000;
                break;
            case 2:
                bikeUpgradeButtons[0].interactable = true;
                bikeUpgradeButtons[1].interactable = true;
                bikeUpgradeButtons[2].interactable = true;
                bikeCost = 8000;
                break;
        }
      
        costTextBike.text = bikeCost.ToString();

       
    }

    void UpgradeBike()
    {
        if (score >= bikeCost)
        {
            bikeTier += 1;
            bikeUpgradeButtons[bikeTier - 1].GetComponent<Image>().color = Color.green;
            bikeUpgradeButtons[bikeTier - 1].onClick.RemoveAllListeners();

          

        }

        gameController.bikeTier = bikeTier;
        
    }

    public void CloseWindow()
    {
        upgradeMenu.SetActive(false);
    }

    



}
