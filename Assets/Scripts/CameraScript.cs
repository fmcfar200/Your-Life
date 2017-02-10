using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    GameObject target;
   

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
        transform.LookAt(target.transform);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDPos = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDPos.x * 1.0f * Time.deltaTime, -touchDPos.y * 1.0f*Time.deltaTime, 0);
        }

        Mathf.Clamp(transform.position.z, -6.0f, -9.0f);
    }

}
