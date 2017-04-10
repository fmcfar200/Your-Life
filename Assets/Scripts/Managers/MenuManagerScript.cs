using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MenuManagerScript : MonoBehaviour {

    public List<GameObject> menus = new List<GameObject>();
    bool menuOpen;
    GameControllerScript gameController;

    public GameObject instructionScreen;

    void Start()
    {
        menuOpen = false;
        foreach(GameObject menu in menus)
        {
            menu.SetActive(false);
        }

        gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();

        if (gameController.instructionPanelRead == true)
        {
            instructionScreen.SetActive(false);
        }

    }

    void Update()
    {
       switch(menuOpen)
        {
            case true:
                Time.timeScale = 0;
                break;
            case false:
                Time.timeScale = 1;
                break;
        }
    }

	public void OpenMenu(string menuName)
    {
            foreach(GameObject menu in menus)
            {
                if (menu.name == menuName)
                {
                    menu.SetActive(true);
                }
                else
                {
                    menu.SetActive(false);
                }
            }

        menuOpen = true;
    }

    public void CloseMenu()
    {
        foreach(GameObject menu in menus)
        {
            menu.SetActive(false);
        }
        menuOpen = false;
    }

    public void CloseInstruction()
    {
        gameController.instructionPanelRead = true;
        instructionScreen.SetActive(false);
    }
}
