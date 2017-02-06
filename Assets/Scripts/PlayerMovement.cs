using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour {

    GameObject player;
    float speed;
    Vector3 hitPoint;
    bool moving;

    void Start()
    {
        player = this.gameObject;
        speed = 2.5f;
        moving = false;
    }

	void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.tag == "Ground")
                {
                    hitPoint = hit.point;
                    moving = true;
                }
            }
        }


        if (moving)
        {
            MoveToPoint(hitPoint);
        }
    }

    void MoveToPoint(Vector3 hitPoint)
    {
        hitPoint.y = 0;
        player.transform.position = Vector3.MoveTowards(player.transform.position,hitPoint,speed*Time.deltaTime);
    }
}
