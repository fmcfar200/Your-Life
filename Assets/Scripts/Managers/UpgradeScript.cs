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

    public Material carMaterial1;
    public Material carMaterial2;
    GameObject carObj;

    GameObject gameControllerObj;
    GameControllerScript gameController;

    public Text costTextBike;
    public Text costTextCar;
    
    int bikeTier;
    int carTier;


    int score;
    int bikeCost;
    int carCost;

    SoundEffects SFX;

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

            carObj = GameObject.Find("JEEP_BODY");
            if (carObj == null)
            {
                Debug.LogError("No car!!!");
            }

            SFX = GameObject.Find("SFXManager").GetComponent<SoundEffects>();
           
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
    }

    void Start()
    {
       
        foreach(Button button in bikeUpgradeButtons)
        {
            button.onClick.AddListener(() => UpgradeBike());
            button.interactable = false;
        }

        foreach(Button button in carUpgradeButtons)
        {
            button.onClick.AddListener(() => UpgradeCar());

            button.interactable = false;
        }
        foreach (GameObject bike in bikes)
        {
            bike.SetActive(false);
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

        switch (carTier)
        {
            case 0:
                carObj.GetComponent<Renderer>().material = carMaterial1;
                carUpgradeButtons[0].interactable = true;
                carCost = 2500;

                break;
            case 1:
                carObj.GetComponent<Renderer>().material = carMaterial2;
                carUpgradeButtons[0].interactable = true;
                carUpgradeButtons[1].interactable = true;
                carCost = 4500;
                break;
            case 2:
                carObj.GetComponent<Renderer>().material = carMaterial2;
                carUpgradeButtons[0].interactable = true;
                carUpgradeButtons[1].interactable = true;
                carUpgradeButtons[2].interactable = true;
                carCost = 8500;
                break;
        }

        costTextBike.text = "Cost: " + bikeCost.ToString();
        costTextCar.text = "Cost: " + carCost.ToString();
    }

    void UpgradeBike()
    {
        if (score >= bikeCost)
        {
            gameController.playerScore -= bikeCost;
            bikeTier += 1;
            bikeUpgradeButtons[bikeTier - 1].GetComponent<Image>().color = Color.green;
            bikeUpgradeButtons[bikeTier - 1].onClick.RemoveAllListeners();
            SFX.PlaySound("Upgrade");
        }
        gameController.bikeTier = bikeTier;
    }

    void UpgradeCar()
    {
        if (score >= carCost)
        {
            gameController.playerScore -= carCost;
            carTier += 1;
            carUpgradeButtons[carTier - 1].GetComponent<Image>().color = Color.green;
            carUpgradeButtons[carTier - 1].onClick.RemoveAllListeners();
            SFX.PlaySound("Upgrade");


        }
        gameController.carTier = carTier;
    }

    public void CloseWindow()
    {
        upgradeMenu.SetActive(false);
    }

    



}
