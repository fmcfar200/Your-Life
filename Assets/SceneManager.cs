using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public void LoadScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
