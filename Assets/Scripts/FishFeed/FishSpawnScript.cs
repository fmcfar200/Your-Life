using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class FishSpawnScript : MonoBehaviour {

    GameObject player;

    bool spawning;
    int wave;
    int maxWave;
    int spawnAmount;
    float spawnDelay;
    float spawnRange = 5;

    public GameObject foodPref;
    public GameObject obstaclePref;
    public List<Transform> obstacleSpawns = new List<Transform>();
    public List<GameObject> powers = new List<GameObject>();
    public GameObject finishPanel;
    public GameObject instructPanel;
    Text messageText;
    Text rewardText;

    GameControllerScript gameController;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawning = true;
        wave = 0;
        maxWave = 5;
        spawnAmount = 5;
        spawnDelay = 1.5f;

        if (finishPanel != null)
        {
            finishPanel.SetActive(false);

            messageText = finishPanel.transform.GetChild(0).GetComponent<Text>();
            rewardText = finishPanel.transform.GetChild(1).GetComponent<Text>();


        }

        gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        if (gameController == null)
        {
            Debug.LogError("Game Controller not found !!!!");
        }

        instructPanel.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(Spawn());
    }

    void Update()
    {
        if (spawning == false)
        {
            Complete();
        }
       
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(3.0f);

        while (spawning)
        {
            if (wave != maxWave)
            {
                for (int i = 0; i < spawnAmount; i++)
                {
                    GameObject food = Instantiate(foodPref, Random.insideUnitCircle * spawnRange, Quaternion.identity) as GameObject;
                    SpawnRandomPower();
                    int randomObstacleInt = Random.Range(-1, 1);
                    if (randomObstacleInt >= 0)
                    {
                        SpawnObs();
                    }

                    yield return new WaitForSeconds(spawnDelay);
                }
                wave++;
                spawnAmount += 2;
                spawnDelay -= 0.25f;
                yield return new WaitForSeconds(3.0f);
            }
            else
            {
                
                if (gameController.fishTier > 0)
                {
                    gameController.healthy += 2 * gameController.fishTier;
                    gameController.active += 2 * gameController.fishTier;
                }
                else
                {
                    gameController.nurtured += 2;
                    gameController.safe += 2;
                }

                gameController.pulse = true;
                spawning = false;

            }
        }
    }

    void SpawnObs()
    {
        GameObject obstacle = Instantiate(obstaclePref, obstacleSpawns[Random.Range(0,obstacleSpawns.Count)].position, Quaternion.identity) as GameObject;
    }

    void SpawnRandomPower()
    {
        int randomChanceInt = Random.Range(0, 5);

        if (randomChanceInt >= 4)
        {
            GameObject power = Instantiate(powers[Random.Range(0,powers.Count)], Random.insideUnitCircle * spawnRange, Quaternion.identity) as GameObject;

        }


    }

    void Complete()
    {
        if (rewardText != null && messageText != null)
        {
            messageText.text = "Complete!";
            rewardText.text = "Score: + " + player.GetComponent<FishPlayerScript>().score;
        }
        else
        {
            Debug.LogError("text not found");
        }

        Time.timeScale = 0;
        finishPanel.SetActive(true);
    }

    public void GameOver()
    {
        if (rewardText != null && messageText != null)
        {
            messageText.text = "Game Over!";
            rewardText.text = "Score: + " + player.GetComponent<FishPlayerScript>().score;
        }
        else
        {
            Debug.LogError("text not found");
        }

        Time.timeScale = 0;
        finishPanel.SetActive(true);
    }

    public void Begin()
    {
        Time.timeScale = 1;
        instructPanel.SetActive(false);
    }

    public void Return()
    {
        SceneManager.LoadScene(2);
    }

}
