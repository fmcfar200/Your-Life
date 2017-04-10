using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    int health;

    public Text healthText;
    public GameObject gOverPanel;
    Text messageText;
    Text rewardText;
    PBSpawnScript spawner;

    void Start()
    {
        health = 3;

        spawner = GameObject.Find("SpawnManager").GetComponent<PBSpawnScript>();
       
        if (gOverPanel != null)
        {
            messageText = gOverPanel.transform.GetChild(0).GetComponent<Text>();
            rewardText = gOverPanel.transform.GetChild(1).GetComponent<Text>();
            gOverPanel.SetActive(false);


        }

    }
    void Update()
    {
        healthText.text = health.ToString();

        if (health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        messageText.text = "Game Over!";
        rewardText.text = "Score: + " + spawner.score;
        Time.timeScale = 0;
        gOverPanel.SetActive(true);
    }

    public void ReturnHome()
    {
        SceneManager.LoadScene(2);
    }

    public void DeductHealth()
    {
        health -= 1;
    }
}
