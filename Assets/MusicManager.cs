using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip houseMusic;
    public AudioClip bikeMusic;
    public AudioClip carMusic;

    AudioSource aSource;

    void Awake()
    {
        DontDestroyOnLoad(this);

        aSource = GetComponent<AudioSource>();
        aSource.loop = true;

        if (aSource != null)
        {
            if (Application.loadedLevelName == "HomeScene")
            {
                aSource.PlayOneShot(houseMusic);
            }
            else if (Application.loadedLevelName == "BikeRide")
            {
                aSource.PlayOneShot(bikeMusic);

            }
            else if (Application.loadedLevelName == "CarRide")
            {
                aSource.PlayOneShot(carMusic);

            }
        }
       
    }

    void Update()
    {
        
    }
}
