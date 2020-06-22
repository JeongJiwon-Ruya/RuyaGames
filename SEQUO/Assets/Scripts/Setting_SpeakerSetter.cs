using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting_SpeakerSetter : MonoBehaviour
{
    public GameObject SpeakerOffImg;
    public GameObject img1, img2, img3, img4;

    public InputField field;
    public GameObject juky;

    //on일때 2,3  off일때 1,4 active
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("MUTE").Equals(0))
        {
            img1.SetActive(false); 
            img2.SetActive(true);
            img3.SetActive(true);
            img4.SetActive(false);
        }
        else
        {
            SpeakerOffImg.SetActive(true);
            img1.SetActive(true);
            img2.SetActive(false);
            img3.SetActive(false);
            img4.SetActive(true);
        }
    }

    public void PersonalInfoButtonClicked()
    {
        Application.OpenURL("http://blog.daum.net/ruyagames");
    }

    public void CodeButtonClicked()
    {
        Debug.Log(field.text);
        if(int.Parse(field.text) == 5252)
        {
            PlayerPrefs.SetInt("REINFORCE_SEQUOIAN_LEAF", 20);
            PlayerPrefs.SetInt("REINFORCE_CLOVER", 20);
            PlayerPrefs.SetInt("REINFORCE_FAIRYS_FEATHER", 20);

            juky.SetActive(true);
        }
    }

 
}
