using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour {

    bool clicked;
    bool promptOpen;

    GameObject quickPrompt;
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
            this.GetComponent<BoxCollider>().enabled = false;
            if (this.gameObject.tag == "Mission Item")
            {
               
                    if (gameObject.name == "Newspaper_Item")
                    {
                        promptOpen = true;
                        promptTitle.text = "Paper Boy/Girl Wanted!";
                        promptDesc.text = "The local newspaper is looking for a new paper boy/girl. Would you like to apply?";

                        yesButton.onClick.AddListener(()=>YesClick());
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
                missionManager.GetNewJob();

                promptOpen = false;
                quickPrompt.SetActive(false);
                promptDesc.text = null;
                promptTitle.text = null;

            }
        }
    }

    void NoClick()
    {
        promptOpen = false;
    }
}
