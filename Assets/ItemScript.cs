using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {

    bool clicked;
  

    void Start()
    {
        clicked = false;
    }

    void Update()
    {
        if (clicked == true)
        {
            this.GetComponent<BoxCollider>().enabled = false;
            if (this.gameObject.tag == "Mission Item")
            {
                MissionManagerScript missionManager;
                GameObject manager = GameObject.Find("MenuManager");
                if (manager != null)
                {
                    missionManager = manager.GetComponent<MissionManagerScript>();
                    if (gameObject.name == "Newspaper_Item")
                    {
                        missionManager.GetNewJob();
                    }
                }
                else
                {
                    Debug.LogError("MANAGER NOT FOUND!");
                }
                clicked = false;
            }

        }
    }

    public void ClickedOnObject()
    {
        Debug.Log("Clicked on " + this.name);
        clicked = true;
    }
}
