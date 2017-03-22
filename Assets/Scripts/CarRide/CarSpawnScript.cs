using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarSpawnScript : MonoBehaviour {

    public List<GameObject> spawns = new List<GameObject>();
    public List<GameObject> cars = new List<GameObject>();

    float spawnDelay;
    bool spawning;
    int wave;
    int maxWave;
    int spawnAmount;
    int scoreReward;

    GameObject gameControllerObj;
    GameControllerScript gameController;

    int carTier;

    public Text message_Text;
    public Text reward_Text;
    public GameObject finish_Panel;

    void Start()
    {
        scoreReward = 0;
        spawning = true;
        wave = 0;
        maxWave = 3;
        finish_Panel.SetActive(false);

        
        gameControllerObj = GameObject.Find("GameController");
        if (gameControllerObj != null)
        {
            gameController = gameControllerObj.GetComponent<GameControllerScript>();
            carTier = gameController.carTier;

            if (carTier == 0)
            {
                spawnDelay = 1.75f;
                spawnAmount = 5;

            }
            else if (carTier == 1)
            {
                spawnDelay = 1;
                spawnAmount = 8;
            }
            else if (carTier > 1)
            {
                spawnDelay = 0.75f;
                spawnAmount = 10;
            }
        }

        StartCoroutine(Spawn());
    }

    void Update()
    {
        if (spawning == false)
        {
            GameObject[] cars = GameObject.FindGameObjectsWithTag("PedCar");
            int carCount = 0;
            foreach (GameObject car in cars)
            {
                carCount++;
            }

            if (carCount == 0)
            {
                Complete();
            }
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
                    GameObject pedCar = Instantiate(cars[Random.Range(0, cars.Count)], spawns[Random.Range(0, spawns.Count)].transform.position, Quaternion.identity) as GameObject;
                    pedCar.tag = "PedCar";
                    yield return new WaitForSeconds(spawnDelay);
                }
                wave++;

                yield return new WaitForSeconds(3.0f);
            }
            else
            {
                if (gameController.carTier > 0)
                {
                    gameController.respected += 2 * gameController.carTier;
                    gameController.responsible += 2 * gameController.carTier;

                    scoreReward += 350 * gameController.carTier;
                }
                else
                {
                    gameController.respected += 2;
                    gameController.responsible += 2;
                    scoreReward += 350;

                }
                spawning = false;
              
            }
        }
    }

   

    public void GameOver()
    {
        finish_Panel.SetActive(true);
        Time.timeScale = 0;
        scoreReward = 100;
        message_Text.text = "Game Over!";
        reward_Text.text = "Score: +" + scoreReward.ToString();
    }

    void Complete()
    {
        Time.timeScale = 0;
        finish_Panel.SetActive(true);

        message_Text.text = "Level Complete!";
        reward_Text.text = "Score: +" + scoreReward.ToString();

    }

    public void ReturnHome()
    {
        gameController.playerScore += scoreReward;
        SceneManager.LoadScene(1);
    }
 }



