using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    int health;

    public Text healthText;
    public GameObject gOverPanel;

    void Start()
    {
        health = 3;
        gOverPanel.SetActive(false);
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
        Time.timeScale = 0;
        gOverPanel.SetActive(true);
    }

    public void ReturnHome()
    {
        SceneManager.LoadScene(1);
    }

    public void DeductHealth()
    {
        health -= 1;
    }
}
