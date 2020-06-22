using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{

    public AdmobAdManager admob;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(GoMain);
    }

    public void AdShow()
    {
        admob.ShowInterstitial();
    }

    void GoMain()
    {

        SceneManager.LoadScene("MainScene");
        if(PlayerPrefs.GetInt("MUTE").Equals(0))
            BGMController.Instance.StartBgm();
    }
    
}
