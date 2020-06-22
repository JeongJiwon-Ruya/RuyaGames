using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlayTutorial : MonoBehaviour
{
    public GameObject Tutorial;
    AudioSource audiosource;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("FIRSTPLAY").Equals(0))
        {
            Tutorial.SetActive(true);
            audiosource.Play();
            PlayerPrefs.SetInt("DAILYAD_REWARD", 5);
            PlayerPrefs.SetInt("FIRSTPLAY", 1);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void GotoMain()
    {
        LoadingSceneManager.LoadScene("MainScene");
    }

  
}
