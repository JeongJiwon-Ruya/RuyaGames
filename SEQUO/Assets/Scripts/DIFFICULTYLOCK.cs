using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DIFFICULTYLOCK : MonoBehaviour
{
    public GameObject NORMAL_LOCK;
    public GameObject HARD_LOCK;
    public GameObject INSANE_LOCK;
    public GameObject HELL;

    void Start()
    {

        if (PlayerPrefs.GetInt("NORMAL_CLEAR").Equals(1))
        {
            NORMAL_LOCK.SetActive(false);
        }
        if (PlayerPrefs.GetInt("HARD_CLEAR").Equals(1))
        {
            HARD_LOCK.SetActive(false);
        }
        if (PlayerPrefs.GetInt("INSANE_CLEAR").Equals(1))
        {
            INSANE_LOCK.SetActive(false);
        }
        if(PlayerPrefs.GetInt("INSANE_ACHIEVE").Equals(2))
        {
            HELL.SetActive(true);
        }
    }

}
