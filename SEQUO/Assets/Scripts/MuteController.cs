using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteController : MonoBehaviour
{
 
    public void OnBtnClick()
    {
        PlayerPrefs.SetInt("MUTE", 1);
        BGMController.Instance.StopBgm();
    }

    public void OffBtnClick()
    {
        PlayerPrefs.SetInt("MUTE", 0);
        BGMController.Instance.StartBgm();
    }
}
