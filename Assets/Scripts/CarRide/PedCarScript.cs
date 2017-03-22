using UnityEngine;
using System.Collections;

public class PedCarScript : MonoBehaviour {

    float speed = 7.5f;
    int bikeTier;
    GameControllerScript gameController;

    bool hitTrigger = false;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        if (gameController != null)
        {
            bikeTier = gameController.bikeTier;
            switch(bikeTier)
            {
                case 0:
                    speed = 7.5f;
                    break;
                case 1:
                    speed = 9.0f;
                    break;
                case 2:
                    speed = 10.0f;
                    break;
                case 3:
                    speed = 12.0f;
                    break;
            }
        }
        else
        {
            Debug.LogError("GameController not found!!");
        }

    }
    void FixedUpdate()
    {
        if (gameObject.tag == "BGRight")
        {
            gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (hitTrigger == true)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 25);
                hitTrigger = false;

            }

        }
        else if (gameObject.tag == "BGLeft")
        {
            gameObject.transform.Translate(-Vector3.left * speed * Time.deltaTime);
            if (hitTrigger == true)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 25);
                hitTrigger = false;

            }

        }
        else
        {
            gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name == "CarDestroyer")
        {
            if (gameObject.tag == "BGLeft" || gameObject.tag == "BGRight")
            {
                Debug.Log("Hit Trigger");
                hitTrigger = true;

            }
            else
            {
                Destroy(gameObject);
               
            }
        }
    }
}
