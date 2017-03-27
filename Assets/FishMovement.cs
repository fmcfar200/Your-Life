using UnityEngine;
using System.Collections;

public class FishMovement : MonoBehaviour {


    float speed;
    float posX;
    float lastPosX;

    Vector3 target;

    int minDistance = 1;


    void Awake()
    {
        lastPosX = transform.position.x;
    }
	void Start ()
    {
        speed = 5.0f;
	}
	
	void Update ()
    {
        Seek();
	}

    void Seek()
    {
        posX = transform.position.x;

        target = Input.mousePosition;
        target = Camera.main.ScreenToWorldPoint(target);

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
}
