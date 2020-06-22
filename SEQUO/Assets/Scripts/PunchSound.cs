using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchSound : MonoBehaviour
{
    protected static PunchSound instance = null;
    public static PunchSound Instance
    {
        get
        {
            instance = FindObjectOfType(typeof(PunchSound)) as PunchSound;

            if (instance == null)
            {
                instance = new GameObject("@" + typeof(PunchSound).ToString(), typeof(PunchSound)).AddComponent<PunchSound>();
            }
            return instance;
        }
    }

    AudioSource audiosource;
    public AudioClip[] audioClip;

    bool isMute()
    {
        if (PlayerPrefs.GetInt("MUTE").Equals(0))
            return false;
        else
            return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    public void HitSound()
    {
        if (!isMute())
        {
            audiosource.PlayOneShot(audioClip[0]);
        }
    }
    public void HitSkillSound()
        {
        if (!isMute())
        {
            audiosource.PlayOneShot(audioClip[1]);
        }
    }

  
}
