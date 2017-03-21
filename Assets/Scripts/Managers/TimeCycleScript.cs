using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TimeCycleScript : MonoBehaviour {

    float maxHourRate = 20.0f;
    float speedUp;
    float nextHour; //Timer until next hour
    bool speedActive;

    public int hour; // current hour
    public int currentDay; // current day array index

    string[] days =
    {
        "Sun","Mon","Tue","Wed","Thu","Fri","Sat"
    }; //Array of days

    //text objects for UI
    public Text dayText;
    public Text hourText;

    //light obj and component
    public GameObject lightObj;
    Light lightComp;

    GameControllerScript gameController;
    GameObject gameControllerObj;


    public List<Material> materials = new List<Material>();

    float overallWellbeing;
    int scoreReward = 2500;
    bool rewardActive = true;
    SoundEffects soundEffects;

    void Start()
    {
        lightComp = lightObj.GetComponent<Light>(); // gets the light component
        speedUp = 1;
        nextHour = maxHourRate * speedUp;
        speedActive = false;

        gameControllerObj = GameObject.Find("GameController");

        if (gameControllerObj!=null)
        {
            gameController = gameControllerObj.GetComponent<GameControllerScript>();
            currentDay = gameController.day;
            hour = gameController.hour;
            overallWellbeing = gameController.overallWellbeing;

        }

        soundEffects = GameObject.Find("SFXManager").GetComponent<SoundEffects>();
        if (soundEffects == null)
        {
            Debug.LogError("SFX not found");
        }

    }

    void Update()
    {
        nextHour = nextHour * speedUp;
        //increases the hour after timer reaches 0
        if (nextHour > 0)
        {
            nextHour -= Time.deltaTime;
        }
        else
        {
            nextHour = 20.0f*speedUp;
            hour += 1;
        }

        //increases day when hour reaches 24
        if (hour >= 24)
        {
            currentDay += 1;
            hour = 0;
        }

        //resets week
        if (currentDay >= 7)
        {
            currentDay = 0;
        }

        //UI code to display day and time
        dayText.text = days[currentDay];

        if (hour >= 0 && hour < 12)
        {
            hourText.text = hour.ToString() + ":00am";

        }
        else
        {
            hourText.text = hour.ToString() + ":00pm";
        }



        //changes lught intensity based on time of day
        if (hour >= 8 && hour <= 19)
        {
            lightComp.intensity = 1;
            RenderSettings.skybox = materials[0];
        }
        else
        {
            lightComp.intensity = 0;
            RenderSettings.skybox = materials[1];

        }

        if (speedActive)
        {
            speedUp = 0.75f;
            hourText.text = hourText.text + "    >>";
        }
        else
        {
            speedUp = 1;
        }

        if (hour == 0 && rewardActive == true)
        {
           GiveDailyReward();
        }
        else if (hour == 1)
        {
            rewardActive = true;
        }

        
      

        gameController.hour = hour;
        gameController.day = currentDay;

        overallWellbeing = gameController.overallWellbeing;


    }

    public void SpeedButton()
    {

        if (speedActive)
        {
            speedActive = false;
        }
        else
        {
            speedActive = true;
        }
    }

    void GiveDailyReward()
    {
        int OWint = (int)overallWellbeing;
        int reward = scoreReward * OWint/500;

        gameController.playerScore += reward;
        rewardActive = false;
        soundEffects.PlaySound("Cash");
        Debug.Log(reward);
    }

    

}
