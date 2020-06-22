using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonGameSFX : MonoBehaviour
{
    protected static NonGameSFX instance = null;
    public static NonGameSFX Instance
    {
        get
        {
            instance = FindObjectOfType(typeof(NonGameSFX)) as NonGameSFX;

            if (instance == null)
            {
                instance = new GameObject("@" + typeof(NonGameSFX).ToString(), typeof(NonGameSFX)).AddComponent<NonGameSFX>();
                DontDestroyOnLoad(instance);

            }
            return instance;
        }
    }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this);
    }

    AudioSource sfxs;
    public AudioClip[] sfxss;
    // Start is called before the first frame update
    void Start()
    {
        sfxs = GetComponent<AudioSource>();
    }
    bool isMute()
    {
        if (PlayerPrefs.GetInt("MUTE").Equals(0))
            return false;
        else
            return true;
    }

    public void PlayShop()
    {
        if (!isMute())
        {
            sfxs.PlayOneShot(sfxss[0]);
        }
    }

    public void BtnClick()
    {
        if (!isMute())
        {
            sfxs.PlayOneShot(sfxss[1]);
        }
    }

    public void FairyClick()
    {
        if (!isMute())
        {
            sfxs.PlayOneShot(sfxss[2]);
        }
    }
}
