using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

using UnityEngine.SceneManagement;
public class CharacterSelectScript : MonoBehaviour {

    public bool newGame;
    public bool isGirl;
    public string Name;

    public Button boySelector;
    public Button girlSelector;

    public InputField inputField;

    public Button loadButton;
    void Start()
    {
        DontDestroyOnLoad(this);
        isGirl = true;
        girlSelector.GetComponent<Image>().color = Color.green;
    }
    void Update()
    {
        if (Application.loadedLevelName == "CharacterEditScene")
        {
            Name = inputField.text;
            if (!File.Exists(Application.persistentDataPath + "/playerData.dat"))
            {
                loadButton.interactable = false;
            }
            else
            {
                loadButton.interactable = true;
            }

        }

       
    }

    public void BoySelect()
    {
        isGirl = false;
        boySelector.GetComponent<Image>().color = Color.green;
        girlSelector.GetComponent<Image>().color = Color.white;
    }
    public void GirlSelect()
    {
        isGirl = true;
        girlSelector.GetComponent<Image>().color = Color.green;
        boySelector.GetComponent<Image>().color = Color.white;

    }

    public void Begin()
    {
        newGame = true;
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            newGame = false;
            SceneManager.LoadScene(1);
        }
    }

}
