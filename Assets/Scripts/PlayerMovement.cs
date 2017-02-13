﻿using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour {

    GameObject player;
    float speed;
    Vector3 hitPoint;
    bool moving;
    bool canMove;

    private Vector3 firstPos;
    private Vector3 lastPos;
    private float dragDistance;
    void Start()
    {
        player = this.gameObject;
        speed = 2.5f;
        moving = false;
        canMove = true;

        dragDistance = Screen.height * 15 / 100;
    }

	void Update()
    {

        /*
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

    */

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                firstPos = touch.position;
                lastPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                lastPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                lastPos = touch.position;

                if (Mathf.Abs(lastPos.x - firstPos.x) > dragDistance || Mathf.Abs(lastPos.y-firstPos.y) > dragDistance)
                {
                    //its a drag so player cannot move
                    canMove = false;
                }
                else
                {
                    //its a tap
                    canMove = true;
                }
            }
        }

        //checks if the input pointer is over a GO instead of a UI object
        
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    if (hit.collider.tag == "Ground" && canMove)
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
