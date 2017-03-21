using UnityEngine;
using System.Collections;

public class SoundEffects : MonoBehaviour {

    public AudioClip select;
    public AudioClip activate;
    public AudioClip timeButton;
    public AudioClip UIClick;
    public AudioClip cash;
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
        else if (type == "LevelSelect")
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
    }
}
