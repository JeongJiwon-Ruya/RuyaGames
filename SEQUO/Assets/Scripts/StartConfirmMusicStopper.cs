using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartConfirmMusicStopper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BGMController.Instance.StopBgm();
    }

}
