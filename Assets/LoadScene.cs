using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

    public GameObject progBar;
    float fillAmount;
    AsyncOperation async;
    void Start()
    {
        async = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        async.allowSceneActivation = false;

    }

    void Update()
    {
        
            progBar.GetComponent<Image>().fillAmount = async.progress;
       
    }

    
}
