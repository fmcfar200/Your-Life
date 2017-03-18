using UnityEngine;
using System.Collections;

public class PedCarScript : MonoBehaviour {

    float speed = 5.0f;
    Vector3 moveBackVec;

    void Start()
    {
        moveBackVec = new Vector3(0, 0, 1);
    }
	void FixedUpdate()
    {
        gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.name == "CarDestroyer")
        {
            Destroy(gameObject);
        }
    }
}
