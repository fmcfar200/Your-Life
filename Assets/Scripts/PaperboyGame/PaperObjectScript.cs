using UnityEngine;
using System.Collections;

public class PaperObjectScript : MonoBehaviour {

    public bool leftThrow = false;
    public bool rightThrow = false;
    float speed = 5.0f;

    void Update()
    {
        if (leftThrow)
        {
            rightThrow = false;
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        else if (rightThrow)
        {
            leftThrow = false;
            transform.Translate(Vector2.right * Time.deltaTime * speed);

        }

        if (transform.position.x >= 10 || transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }
}
