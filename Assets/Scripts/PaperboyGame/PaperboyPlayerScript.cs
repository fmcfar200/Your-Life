using UnityEngine;
using System.Collections;

public class PaperboyPlayerScript : MonoBehaviour {

    Vector2 paperSpawn;
    GameObject player;
    GameObject paperObj;
    public GameObject paperPrefab;

    float throwSpeed;

    void Start()
    {
        player = this.gameObject;
        paperSpawn = player.transform.position;
        throwSpeed = 10.0f;

    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (Input.GetTouch(0).position.x > Screen.width / 2)
                {
                    paperObj = Instantiate(paperPrefab, paperSpawn, Quaternion.identity) as GameObject;
                    paperObj.GetComponent<PaperObjectScript>().rightThrow = true;
                }
                else
                {
                    //throw is to the left side
                    paperObj = Instantiate(paperPrefab, paperSpawn, Quaternion.identity) as GameObject;
                    paperObj.GetComponent<PaperObjectScript>().leftThrow = true;
                }
            }
        }

        else if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                paperObj = Instantiate(paperPrefab, paperSpawn, Quaternion.identity) as GameObject;
                paperObj.GetComponent<PaperObjectScript>().rightThrow = true;
            }
            else
            {
                //throw is to the left side
                paperObj = Instantiate(paperPrefab, paperSpawn, Quaternion.identity) as GameObject;
                paperObj.GetComponent<PaperObjectScript>().leftThrow = true;
            }
        }

     

    }
}
