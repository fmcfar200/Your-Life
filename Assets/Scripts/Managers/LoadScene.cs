using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

    public GameObject progBar;
    float fillAmount;
    AsyncOperation async;

    CharacterSelectScript characterSelectScript;
    void Start()
    {
        characterSelectScript = GameObject.Find("CharacterSelectManager").GetComponent<CharacterSelectScript>();
        if (characterSelectScript != null)
        {
            if (characterSelectScript.newGame == true)
            {
                async = SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
                async.allowSceneActivation = true;
            }
            else
            {
                GameObject.Find("GameController").GetComponent<GameControllerScript>().LoadFromStart();
                async = SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
                async.allowSceneActivation = true;
            }
        }
      
       

    }

    void Update()
    {
        
            progBar.GetComponent<Image>().fillAmount = async.progress;
            
    }

    
}
