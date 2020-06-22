using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    public AudioClip[] SeasonBgm = new AudioClip[4];
    public AudioClip GameBgm;
    AudioSource audioSource;


    protected static BGMController instance = null;
    public static BGMController Instance
    {
        get
        {
            instance = FindObjectOfType(typeof(BGMController)) as BGMController;

            if (instance == null)
            {
                instance = new GameObject("@" + typeof(BGMController).ToString(), typeof(BGMController)).AddComponent<BGMController>();
                DontDestroyOnLoad(instance);
            }
            return instance;
        }
    }

    private int previousSeason = 10;

    private int _index = 4;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
    }

    bool isMute()
    {
        if (PlayerPrefs.GetInt("MUTE").Equals(0))
            return false;
        else
            return true;
    }

    public void ReceiveData(int season)
    {
        if(previousSeason == 10)
        {
            ChangeBGM(season);
        } else if(previousSeason == season)
        {
        }
        else
        {
            ChangeBGM(season);
        }
        
        previousSeason = season;

    }

    private void ChangeBGM(int index)
    {
        _index = index;
        if (!isMute())
        {
            audioSource.clip = SeasonBgm[index];
            audioSource.Play();
        }
    }

    public void StartBgm()
    {
        audioSource.clip = SeasonBgm[_index];
        audioSource.Play();
    }

    public void StopBgm()
    {
        audioSource.Stop();
    }

    public void GameStart_BGM()
    {
        audioSource.clip = GameBgm;
        audioSource.Play();
    }

}
