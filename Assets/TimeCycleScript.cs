using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeCycleScript : MonoBehaviour {

    float nextHour = 20.0f;
    int hour;
    int currentDay;

    string[] days =
    {
        "Sun","Mon","Tue","Wed","Thu","Fri","Sat"
    };

    public Text dayText;
    public Text hourText;
    public GameObject lightObj;
    Light lightComp;

    void Start()
    {
        lightComp = lightObj.GetComponent<Light>();
        currentDay = 0;
        hour = 00;
    }

    void Update()
    {

        if (nextHour > 0)
        {
            nextHour -= Time.deltaTime;
        }
        else
        {
            nextHour = 20.0f;
            hour += 1;
        }

        if (hour >= 24)
        {
            currentDay += 1;
            hour = 0;
        }

        if (currentDay >= 7)
        {
            currentDay = 0;
        }

        dayText.text = days[currentDay];

        if (hour >= 0 && hour < 12)
        {
            hourText.text = hour.ToString() + ":00am";
        }
        else
        {
            hourText.text = hour.ToString() + ":00pm";
        }

        if (hour >= 8 && hour <= 19)
        {
            lightComp.intensity = 1;
        }
        else
        {
            lightComp.intensity = 0;
        }
    }

    

}
