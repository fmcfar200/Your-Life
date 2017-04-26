using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColourPulse : MonoBehaviour {

    Image image;
    Color pulseColour = Color.blue;
    bool pulsing;
    GameControllerScript controller;

    void Start()
    {
        image = GetComponent<Image>();
        controller = GameObject.Find("GameController").GetComponent<GameControllerScript>();
    }
	// Update is called once per frame
	void Update () {
        pulsing = controller.pulse;
        if (pulsing)
        {
            pulseColour = Color.Lerp(Color.blue, Color.clear, Mathf.PingPong(Time.time, 1));
            image.color = pulseColour;
        }
        else
        {
            image.color = Color.clear;
        }
       
	}
}
