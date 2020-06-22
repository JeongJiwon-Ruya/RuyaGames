using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectController : MonoBehaviour
{
    //0=기본공격, 1=스킬공격 2=하이페츠스킬 3=히아신스스킬 4=아리아스킬 5=조합표소리 6=라운드시작소리 7=게임오버 8=게임클리어
    public AudioClip[] audioclips;

    AudioSource audios;

    protected static SoundEffectController instance = null;
    public static SoundEffectController Instance
    {
        get
        {
            instance = FindObjectOfType(typeof(SoundEffectController)) as SoundEffectController;

            if (instance == null)
            {
                instance = new GameObject("@" + typeof(SoundEffectController).ToString(), typeof(SoundEffectController)).AddComponent<SoundEffectController>();
            }
            return instance;
        }
    }

    bool isMute()
    {
        if (PlayerPrefs.GetInt("MUTE").Equals(0))
            return false;
        else
            return true;
    }

    void Start()
    {
        audios = GetComponent<AudioSource>();
    }

    public void HitSound()
    {
        if (!isMute())
        {
            audios.PlayOneShot(audioclips[0]);
        }
    }

    public void HitSkillSound()
    {
        if (!isMute())
        {
            audios.PlayOneShot(audioclips[1]);
        }
    }

    public void HeifetzSkillSound()
    {
        if (!isMute())
        {
            audios.PlayOneShot(audioclips[2]);
        }
    }
    public void HyacinthSkillSound()
    {
        if (!isMute())
        {
            audios.PlayOneShot(audioclips[3]);
        }
    }
    public void AriaSkillSound()
    {
        if (!isMute())
        {
            audios.PlayOneShot(audioclips[4]);
        }
    }
    public void ResultBoxClickSound()
    {
        if (!isMute())
        {
            audios.PlayOneShot(audioclips[5]);
        }
    }
    public void RoundStartSound()
    {
        if (!isMute())
        {
            audios.PlayOneShot(audioclips[6]);
        }
    }
    public void GameOverSound()
    {
        if (!isMute())
        {
            audios.PlayOneShot(audioclips[7]);
        }
    }
    public void GameClearSound()
    {
        if (!isMute())
        {
            audios.PlayOneShot(audioclips[8]);
        }
    }
    public void BoxOpenSound()
    {
        if (!isMute())
        {
            audios.PlayOneShot(audioclips[9]);
        }
    }

}
