using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {

    void Update()
    {
        if(this.transform.position.y <= -5)
        {
            Destroy(this.gameObject);
        }
    }
}
