using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour {

    //GO and Buttons
    GameObject upgradeMenu;
    public List<Button> bikeUpgradeButtons = new List<Button>();
    public List<Button> carUpgradeButtons = new List<Button>();

    GameObject gameControllerObj;
    GameControllerScript gameController;

    public Text costTextBike;

    //
    int bikeTier;
    int carTier;


    int score;
    int bikeCost;
    int carCost;


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
        }
        upgradeMenu.SetActive(false);
    }

    void Start()
    {
        bikeTier = 0;
        carTier = 0;

        foreach(Button button in bikeUpgradeButtons)
        {
            button.onClick.AddListener(() => UpgradeBike());
            button.interactable = false;
        }

    }

    void Update()
    {
        score = gameController.playerScore;

        if (bikeTier == 0)
        {
            bikeUpgradeButtons[0].interactable = true;
            bikeCost = 2000;
        }
        else if (bikeTier == 1)
        {
            bikeUpgradeButtons[0].interactable = true;
            bikeUpgradeButtons[1].interactable = true;
            bikeCost = 4000;
        }
        else if (bikeTier == 2)
        {
            bikeUpgradeButtons[0].interactable = true;
            bikeUpgradeButtons[1].interactable = true;
            bikeUpgradeButtons[2].interactable = true;
            bikeCost = 8000;
        }

        costTextBike.text = bikeCost.ToString();
    }

    void UpgradeBike()
    {
        if (score >= bikeCost)
        {
            bikeTier += 1;
        }
        
    }

    public void CloseWindow()
    {
        upgradeMenu.SetActive(false);
    }



}
