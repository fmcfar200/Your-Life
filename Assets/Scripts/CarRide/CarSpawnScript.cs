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

    void Start()
    {
        spawnDelay = 2.0f;
        spawning = true;
        wave = 0;
        maxWave = 3;
        spawnAmount = 5;

        gameControllerObj = GameObject.Find("GameController");
        if (gameControllerObj != null)
        {
            gameController = gameControllerObj.GetComponent<GameControllerScript>();
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
                gameController.respected += 3;
                gameController.responsible += 3;
                spawning = false;
            }
        }
    }
}
