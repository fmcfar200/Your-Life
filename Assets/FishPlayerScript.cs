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
    public Text healthText;
    public Text scoreText;

    FishSpawnScript spawner;
    GameControllerScript gameController;

    bool multiplierActive;
    int multi;
    float timer;

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
        multi = 1;
        timer = 0;
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
        healthText.text = health.ToString();

        if (health == 0)
        {
            GetComponent<SpriteRenderer>().flipY = true;
            spawner.GameOver();
        }

        if (multiplierActive)
        {
            multi = 2;
            timer += Time.deltaTime;
            if (timer >= 10)
            {
                multi = 1;
                timer = 0;
                multiplierActive = false;
            }
            
        }
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
            AddScore(10);
            aSource.PlayOneShot(eat);
            
        }
        else if (coll.gameObject.tag == "Obstacle")
        {
            if (health > 0)
            {
                health--;
                Destroy(coll.gameObject);
                aSource.PlayOneShot(hit);

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
            AddScore(250);
            Destroy(coll.gameObject);
            aSource.PlayOneShot(eat);

        }
        else if (coll.gameObject.tag == "Multiplier")
        {
            multiplierActive = true;
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
