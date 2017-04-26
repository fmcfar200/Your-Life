using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationScript : MonoBehaviour {

    Animator animator;

    PlayerMovement playerMovementScript;
    void Start()
    {
        if (this.gameObject.tag == "Player")
        {
            playerMovementScript = GetComponent<PlayerMovement>();
        }


       

    }

   
}
