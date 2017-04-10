using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class CharacterSelectScript : MonoBehaviour {

    public bool isGirl;
    public string Name;

    public Button boySelector;
    public Button girlSelector;

    public InputField inputField;

    void Start()
    {
        DontDestroyOnLoad(this);
        isGirl = true;
        girlSelector.GetComponent<Image>().color = Color.green;
    }
    void Update()
    {
        Name = inputField.text;
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
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
