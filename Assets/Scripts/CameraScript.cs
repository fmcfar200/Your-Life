using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    GameObject target;
    public bool orbitLeft = false;
    public bool orbitRight = false;
    public bool orbitUp = false;
    public bool orbitDown = false;

	void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (target == null)
        {
            Debug.LogError("CAMERA CANNOT FIND PLAYER!");
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

    public void DisableOrbit()
    {
        orbitLeft = false;
        orbitRight = false;
        orbitUp = false;
        orbitDown = false;
    }


}
