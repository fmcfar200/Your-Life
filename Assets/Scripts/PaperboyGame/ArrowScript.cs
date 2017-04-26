using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {

    GameObject healthManager;
    Health health;
    PBSpawnScript spawner;

    void Start()
    {
        spawner = GameObject.Find("SpawnManager").GetComponent<PBSpawnScript>();
        if (spawner == null)
        {
            Debug.LogError("No spawn manager found!!");

        }
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
            spawner.streak = 0;
            Destroy(this.gameObject);
        }
    }
}
