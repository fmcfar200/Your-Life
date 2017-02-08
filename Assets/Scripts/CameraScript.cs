using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    GameObject target;
    public bool orbitLeft = false;
    public bool orbitRight = false;
    public bool orbitUp = false;
    public bool orbitDown = false;

    //input variables
    float startTime;
    Vector2 startPos;
    bool couldSwipe;
    float maxSwipeTime = 2.0f;

	void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (target == null)
        {
            Debug.LogError("CAMERA CANNOT FIND PLAYER!");
        }

	}

    void Update()
    {
        
       if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    couldSwipe = true;
                    startPos = touch.position;
                    startTime = Time.time;
                    break;

                case TouchPhase.Moved:
                    couldSwipe = true;
                    break;

                case TouchPhase.Stationary:
                    couldSwipe = false;
                    break;
                case TouchPhase.Ended:
                    float swipeTime = Time.time - startTime;
                    float swipeDistance = (touch.position - startPos).magnitude;

                    if (couldSwipe)
                    {
                        float swipeDirectionX = Mathf.Sign(touch.position.x - startPos.x);
                        float swipeDirectionY = Mathf.Sign(touch.position.y - startPos.y);

                        if (swipeDirectionX == -1)
                        {
                            orbitLeft = true;
                            StartCoroutine(DisableOrbit(1.5f));
                        }
                        else if (swipeDirectionX == 1)
                        {
                            orbitRight = true;
                            StartCoroutine(DisableOrbit(1.5f));
                        }
                        else if (swipeDirectionY == -1)
                        {
                            orbitDown = true;
                            StartCoroutine(DisableOrbit(1.5f));
                        }
                        else if (swipeDirectionY == 1)
                        {
                            orbitUp = true;
                            StartCoroutine(DisableOrbit(1.5f));
                        }

                    }
                    break;


            }
        }
        
    }

	
	void FixedUpdate()
    {
	    if (target !=null)
        {
            transform.LookAt(target.transform);
        }

        if (orbitLeft)
        {
            transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * 20.0f);
        }
        else if (orbitRight)
        {
            transform.RotateAround(target.transform.position, -Vector3.up, Time.deltaTime * 20.0f);
        }
        else if (orbitUp)
        {
            transform.RotateAround(target.transform.position, Vector3.right, Time.deltaTime * 20.0f);
        }
        else if (orbitDown)
        {
            transform.RotateAround(target.transform.position, Vector3.left, Time.deltaTime * 20.0f);
        }
    }

    public void SetOrbit(string direction)
    {
        if (direction == "Left")
        {
            orbitLeft = true;
        }
        else if (direction == "Right")
        {
            orbitRight = true;
        }
        else if (direction == "Up")
        {
            orbitUp = true;
        }
        else if (direction == "Down")
        {
            orbitDown = true;
        }
    }

    IEnumerator DisableOrbit(float time)
    {
        yield return new WaitForSeconds(time);
        orbitLeft = false;
        orbitRight = false;
        orbitUp = false;
        orbitDown = false;
    }


}
