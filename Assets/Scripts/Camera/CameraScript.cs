using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    GameObject target;
    Camera cam;
    float zoomSpeed = 0.5f;

	void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        cam = this.gameObject.GetComponent<Camera>();
        if (target == null)
        {
            Debug.LogError("CAMERA CANNOT FIND PLAYER!");
        }
	}

    void Update()
    {
        transform.LookAt(target.transform);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDPos = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDPos.x * 3.0f * Time.deltaTime, -touchDPos.y * 3.0f*Time.deltaTime, 0);
        }
        //zoom code
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 tZeroPrevTouchPos = touchZero.position - touchZero.deltaPosition;
            Vector2 tOnePrevTouchPos = touchOne.position - touchOne.deltaPosition;

            //distance between touches in each frame
            float prevTouchDeltaMag = (tZeroPrevTouchPos - tOnePrevTouchPos).magnitude;
            float touchMag = (touchZero.position - touchOne.position).magnitude;

            //differences in touches distance
            float dMagDifference = prevTouchDeltaMag - touchMag;

            if (!cam.orthographic)
            {
                cam.fieldOfView += dMagDifference * zoomSpeed;

                // Clamp the field of view to make sure it's between 0 and 180.
                cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 20.0f, 100.0f);
            }
        }

        /*
        if (Input.GetMouseButton(1))
        {
            Vector2 mouseCurrentPos = Input.mousePosition;
            Vector2 mouseLastPos = mouseCurrentPos;
            Vector2 mouseDeltaPos = mouseCurrentPos - mouseLastPos;

            transform.Translate(-mouseDeltaPos.x * 3.0f * Time.deltaTime, -mouseDeltaPos.y * 3.0f * Time.deltaTime, 0);

            Debug.Log("true");

        }
        */

        Mathf.Clamp(transform.position.z, -6.0f, -9.0f);
    }

}
