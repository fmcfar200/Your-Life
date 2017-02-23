using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour {

    bool clicked;
    bool promptOpen;
    GameObject clickedItem;

    public GameObject quickPrompt;
    Text promptTitle;
    Text promptDesc;
    Button yesButton;
    Button noButton;


    void Start()
    {
        clicked = false;
        promptOpen = false;
        quickPrompt = GameObject.Find("Quick_Prompt");
        if (quickPrompt != null)
        {
            promptTitle = quickPrompt.transform.FindChild("Prompt_Title_Text").GetComponent<Text>();
            promptDesc = quickPrompt.transform.FindChild("Prompt_Desc_Text").GetComponent<Text>();
            yesButton = quickPrompt.transform.FindChild("Yes_Button").GetComponent<Button>();
            noButton = quickPrompt.transform.FindChild("No_Button").GetComponent<Button>();
        }
        else
        {
            Debug.LogError("QP not found !!");

        }
    }

    void Update()
    {
        if (clicked == true)
        {
            if (gameObject.tag == "Mission Item")
            {
                 if (this.gameObject.name == "Bike")
                {
                    promptOpen = true;
                    promptTitle.text = "Bike Ride!";
                    promptDesc.text = "Playing this game will increase your Active and Health stats. Would you like to begin?";
                    yesButton.onClick.AddListener(() => YesClick());
                    noButton.onClick.AddListener(() => NoClick());
                }
            }
            else
            {
                Debug.LogError("MANAGER NOT FOUND!");
            }
            clicked = false;
        }
        
        if (promptOpen == true)
        {
            quickPrompt.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            quickPrompt.SetActive(false);
        }
        
    }

    public void ClickedOnObject()
    {
        Debug.Log("Clicked on " + this.name);
        clicked = true;
    }

    void YesClick()
    {
        MissionManagerScript missionManager;
        GameObject manager = GameObject.Find("MenuManager");
        if (manager != null)
        {
            missionManager = manager.GetComponent<MissionManagerScript>();
            if (gameObject.name == "Newspaper_Item")
            {
                this.GetComponent<BoxCollider>().enabled = false;

                promptOpen = false;
                quickPrompt.SetActive(false);
                promptDesc.text = null;
                promptTitle.text = null;

                missionManager.currentMission++;
            }
            if (gameObject.name == "Bike")
            {

                promptOpen = false;
                quickPrompt.SetActive(false);
                promptDesc.text = null;
                promptTitle.text = null;

                Application.LoadLevel("BikeRide");

            }
        }
    }

    void NoClick()
    {
        promptOpen = false;
    }
}
