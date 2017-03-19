using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {

    GameObject healthManager;
    Health health;

    void Start()
    {
        healthManager = GameObject.Find("HealthManager");
        if (healthManager != null)
        {
            health = healthManager.GetComponent<Health>();
        }
        else
        {
            Debug.LogError("No health manager found!!");
        }
    }

    void Update()
    {
        if(this.transform.position.y <= -5)
        {
            health.DeductHealth();
            Destroy(this.gameObject);
        }
    }
}
