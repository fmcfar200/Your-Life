using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CarSpawnScript : MonoBehaviour {

    public List<GameObject> spawns = new List<GameObject>();
    public List<GameObject> cars = new List<GameObject>();

    float spawnDelay;
    bool spawning;
    int wave;
    int maxWave;
    int spawnAmount;
    int score;

    GameObject gameControllerObj;
    GameControllerScript gameController;

    int carTier;


    void Start()
    {
        spawning = true;
        wave = 0;
        maxWave = 3;

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
                spawnDelay = 1.5f;
                spawnAmount = 8;
            }
            else if (carTier > 1)
            {
                spawnDelay = 1.25f;
                spawnAmount = 10;
            }
        }

        StartCoroutine(Spawn());
    }

    void Update()
    {
        if (spawning == false)
        {
            SceneManager.LoadScene(1);
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
                    Instantiate(cars[Random.Range(0, cars.Count)], spawns[Random.Range(0, spawns.Count)].transform.position, Quaternion.identity);

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
                }
                else
                {
                    gameController.respected += 2;
                    gameController.responsible += 2;
                }
                spawning = false;

            }
        }
        }
 }

