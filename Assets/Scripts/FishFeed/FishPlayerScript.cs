using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class FishPlayerScript : MonoBehaviour {


    float speed;
    float posX;
    float lastPosX;

    Vector3 target;
    int minDistance = 1;

    public int score;
    int health;
    public Text scoreText;
    public Image healthBar;
    float percent;
    FishSpawnScript spawner;
    GameControllerScript gameController;

    bool ironActive;
    float ironTimer;

    bool multiplierActive;
    int multi;
    float multiTimer;

    public AudioClip eat;
    public AudioClip hit;
    AudioSource aSource;

    void Awake()
    {
        lastPosX = transform.position.x;
    }
	void Start ()
    {
        speed = 5.0f;
        score = 0;
        health = 3;
        multiplierActive = false;
        ironActive = false;
        multi = 1;
        multiTimer = 0;
        ironTimer = 0;
        aSource = GetComponent<AudioSource>();

        spawner = GameObject.Find("SpawnManager").GetComponent<FishSpawnScript>();
        if (spawner == null)
        {
            Debug.LogError("Spawner Not Found");
        }
        gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        if (gameController == null)
        {
            Debug.LogError("Game Controller not found !!!!");
        }
	}
	
	void Update ()
    {
        Seek();
        scoreText.text = "Score: " + score.ToString();

        if (health == 0)
        {
            GetComponent<SpriteRenderer>().flipY = true;
            spawner.GameOver();
        }

        if (multiplierActive)
        {
            multi = 2;
            multiTimer += Time.deltaTime;
            if (multiTimer >= 10)
            {
                multi = 1;
                multiTimer = 0;
                multiplierActive = false;
            }
            
        }

        if (ironActive)
        {
            ironTimer += Time.deltaTime;
            if (ironTimer >= 10)
            {
                ironTimer = 0;
                ironActive = false;
            }

        }

        percent = health / 3.0f;
        Debug.Log(percent.ToString());
        healthBar.fillAmount = percent;
    }

    void Seek()
    {
        posX = transform.position.x;

        if (Input.touchCount > 0)
        {
            target = Input.GetTouch(0).position;
            target = Camera.main.ScreenToWorldPoint(target);
        }
        else
        {
            target = Input.mousePosition;
            target = Camera.main.ScreenToWorldPoint(target);
        }

        Vector3 direction = target - transform.position;
        direction.z = 1;
        
        if (direction.magnitude > minDistance)
        {
            Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
            transform.position += moveVector;
        }

        if (posX < lastPosX)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;

        }
        lastPosX = posX;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "FishFood")
        {
            Destroy(coll.gameObject);
            AddScore(3);
            aSource.PlayOneShot(eat);
            
        }
        else if (coll.gameObject.tag == "Obstacle")
        {
            if (!ironActive)
            {
                if (health > 0)
                {
                    health--;
                    Destroy(coll.gameObject);
                    aSource.PlayOneShot(hit);

                }
            }
            else
            {
                Destroy(coll.gameObject);
                AddScore(10);
                aSource.PlayOneShot(eat);
            }

        }
        else if (coll.gameObject.tag == "Health")
        {
            if (health < 3)
            {
                health++;
                Destroy(coll.gameObject);

            }
            else
            {
                Destroy(coll.gameObject);
            }
            aSource.PlayOneShot(eat);


        }
        else if (coll.gameObject.tag == "Score")
        {
            AddScore(100);
            Destroy(coll.gameObject);
            aSource.PlayOneShot(eat);

        }
        else if (coll.gameObject.tag == "Multiplier")
        {
            multiplierActive = true;
            Destroy(coll.gameObject);
            aSource.PlayOneShot(eat);

        }
        else if (coll.gameObject.tag == "IronStomach")
        {
            ironActive = true;
            Destroy(coll.gameObject);
            aSource.PlayOneShot(eat);

        }

    }

    void AddScore(int amount)
    {
        score += amount * multi;
        gameController.playerScore += amount * multi;
    }

    
}
