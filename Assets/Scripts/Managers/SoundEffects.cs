using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundEffects : MonoBehaviour {

    public AudioClip select;
    public AudioClip activate;
    public AudioClip timeButton;
    public AudioClip UIClick;
    public AudioClip cash;
    public AudioClip fail;

    public List<AudioClip> bikeCorrectSFX = new List<AudioClip>();
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(string type)
    {
        if (type == "UI")
        {
            source.PlayOneShot(UIClick);
        }
        else if (type == "Select")
        {
            source.PlayOneShot(select);
        }
        else if (type == "LevelSelect" || type == "Upgrade")
        {
            source.PlayOneShot(activate);
        }
        else if (type == "Time")
        {
            source.PlayOneShot(timeButton);
        }
        else if (type == "Cash")
        {
            source.PlayOneShot(cash);

        }

        else if (type == "Fail")
        {
            source.PlayOneShot(fail);

        }
        else if (type == "Correct")
        {
            int random = Random.Range(0, bikeCorrectSFX.Count);
            source.PlayOneShot(bikeCorrectSFX[random]);
        }

    }
}
