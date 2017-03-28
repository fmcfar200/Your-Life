using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FishSpawnScript : MonoBehaviour {

    bool spawning;
    int wave;
    int maxWave;
    int spawnAmount;
    float spawnDelay;
    float spawnRange = 5;

    public GameObject foodPref;
    public GameObject obstaclePref;

    Color color;

    public GameObject finishPanel;
    Text messageText;
    Text rewardText;

    int score;

    void Start()
    {
        score = 0;
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

        StartCoroutine(Spawn());
    }

    void Update()
    {

        if (spawning == false)
        {
            Complete();
        }
        color = new Vector4(Random.Range(0, 225), 
            Random.Range(0, 225), Random.Range(0, 225), 225);
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
                    food.tag = "FishFood";
                    food.GetComponent<SpriteRenderer>().color = color;

                    int randomObstacleInt = Random.Range(-1, 1);
                    if (randomObstacleInt >= 0)
                    {
                        GameObject obstacle = Instantiate(obstaclePref, Random.insideUnitCircle * spawnRange, Quaternion.identity) as GameObject;

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
                /*
                if (gameController.bikeTier > 0)
                {
                    gameController.healthy += 2 * gameController.bikeTier;
                    gameController.active += 2 * gameController.bikeTier;
                }
                else
                {
                    gameController.healthy += 2;
                    gameController.active += 2;
                }
                */
                spawning = false;

            }
        }
    }

    void Complete()
    {
        if (rewardText != null && messageText != null)
        {
            messageText.text = "Complete!";
            rewardText.text = "Score: + " + score;
        }
        else
        {
            Debug.LogError("text not found");
        }

        Time.timeScale = 0;
        finishPanel.SetActive(true);
    }

    public void Return()
    {
        SceneManager.LoadScene(1);
    }

}
