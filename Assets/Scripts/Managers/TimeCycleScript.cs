﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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


    void Start()
    {
        lightComp = lightObj.GetComponent<Light>(); // gets the light component
        currentDay = 0;
        hour = 9;
        speedUp = 1;
        nextHour = maxHourRate * speedUp;
        speedActive = false;


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
        }
        else
        {
            lightComp.intensity = 0;
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

    

}