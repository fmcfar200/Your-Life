using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CarMovement : MonoBehaviour
{

    GameObject car;
    GameObject spawnManager;
    CarSpawnScript spawnScript;

    public GameObject shield;
    bool shieldActive = false;
    void Start()
    {
        car = this.gameObject;

        spawnManager = GameObject.Find("SpawnManager");
        if (spawnManager != null)
        {
            spawnScript = spawnManager.GetComponent<CarSpawnScript>();
        }
        else
        {
            Debug.Log("Spawn manager not found");
        }

        shieldActive = false;
       
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                    {
                        if (hit.collider.gameObject.tag == "Lane")
                        {
                            Transform lane = hit.collider.transform;
                            car.transform.position = lane.position;
                        }
                    }
                }
            }
        }
        else
        {
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 100.0f))
                    {
                        if (hit.collider.gameObject.tag == "Lane")
                        {
                            Transform lane = hit.collider.transform;
                            car.transform.position = lane.position;
                        }
                    }
                }
            }
        }

        switch(shieldActive)
        {
            case true:
                shield.SetActive(true);
                break;
            case false:
                shield.SetActive(false);

                break;

        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "PedCar")
        {
            if (shieldActive == true)
            {
                Destroy(coll.gameObject);
                shieldActive = false;
            }
            else
            {
                spawnScript.GameOver();
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Shield")
        {
            shieldActive = true;
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.tag == "Multiplier")
        {
            spawnScript.scoreReward += 250;
            Destroy(coll.gameObject);

        }
    }



}


