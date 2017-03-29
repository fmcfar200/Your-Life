using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour {

    bool clicked;
    bool promptOpen;
    GameObject clickedItem;

    public GameObject quickPrompt;
    public GameObject upgradeMenu;

    Text promptTitle;
    Text promptDesc;
    Button yesButton;
    Button noButton;

    GameObject SFXManager;
    SoundEffects soundEffects;
    
    
    void Awake()
    {
       
        clicked = false;
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

        SFXManager = GameObject.Find("SFXManager");
        if (SFXManager != null)
        {
            soundEffects = SFXManager.GetComponent<SoundEffects>();
        }
        else
        {
            Debug.Log("sfx manager not found");
        }
    }

    void Start()
    {
        quickPrompt.SetActive(false);
    }

    void Update()
    {

        if (clicked == true)
        {

            if (gameObject.tag == "Mission Item")
            {
                soundEffects.PlaySound("Select");
                if (gameObject.name == "Bike")
                {
                    quickPrompt.SetActive(true);
                    promptTitle.text = "Bike Ride!";
                    promptDesc.text = "Playing this game will increase your Active and Health stats. Would you like to begin?";
                    yesButton.onClick.AddListener(() => YesClick());
                    noButton.onClick.AddListener(() => NoClick());
                }

                if (gameObject.name == "Car")
                {
                    quickPrompt.SetActive(true);
                    promptTitle.text = "Car";
                    promptDesc.text = "Playing this game will increase your Responsible and Respectful stats. Would you like to begin?";
                    yesButton.onClick.AddListener(() => YesClick());
                    noButton.onClick.AddListener(() => NoClick());
                }

                if (gameObject.name == "TV")
                {
                    upgradeMenu.SetActive(true);
                }

                if (gameObject.name == "Fish Tank")
                {
                    quickPrompt.SetActive(true);
                    promptTitle.text = "Fish Feed";
                    promptDesc.text = "Playing this game will increase your Safe and Nurturing stats. Would you like to begin?";
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
        
       
        
    }

    public void ClickedOnObject()
    {
        Debug.Log("Clicked on " + this.name);
        clicked = true;
    }

    void YesClick()
    {
        soundEffects.PlaySound("Activate");
        MissionManagerScript missionManager;
        GameObject manager = GameObject.Find("MenuManager");
        if (manager != null)
        {
            missionManager = manager.GetComponent<MissionManagerScript>();
            
            if (gameObject.name == "Bike")
            {

                promptOpen = false;
                quickPrompt.SetActive(false);
                promptDesc.text = null;
                promptTitle.text = null;

                Application.LoadLevel("BikeRide");

            }
            if (gameObject.name == "Car")
            {

                promptOpen = false;
                quickPrompt.SetActive(false);
                promptDesc.text = null;
                promptTitle.text = null;

                Application.LoadLevel("CarRide");

            }
            if (gameObject.name == "Fish Tank")
            {

                promptOpen = false;
                quickPrompt.SetActive(false);
                promptDesc.text = null;
                promptTitle.text = null;

                Application.LoadLevel("FishFeeder");

            }
        }
    }

    void NoClick()
    {
        quickPrompt.SetActive(false);
        soundEffects.PlaySound("UI");
    }
}
