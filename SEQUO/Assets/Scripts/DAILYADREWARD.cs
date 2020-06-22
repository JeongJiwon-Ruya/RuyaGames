using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class DAILYADREWARD : MonoBehaviour
{
    public Button ShowAdButton;

    void Start()
    {
        ShowAdButton.onClick.AddListener(ShowAdButtonClick);
        ShowAdButton.interactable = false;

        string BeforeSplit_past_time = PlayerPrefs.GetString("TIME");
        string[] pastTime = BeforeSplit_past_time.Split('-');
        string[] current_time = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm").Split('-');
        //0 = 연도    1 = 달   2 = 날짜      3 = 시       4 = 분

        if (PlayerPrefs.GetInt("DAILYAD_REWARD").Equals(1))
        {
            ShowAdButton.interactable = true;
        }

        //같은달
        if (pastTime[1].Equals(current_time[1]))
        {
            //같은일
            if (pastTime[2].Equals(current_time[2]))
            {
                if (PlayerPrefs.GetInt("DAILYAD_REWARD").Equals(2))
                { ShowAdButton.interactable = false;  }

                else if (PlayerPrefs.GetInt("DAILYAD_REWARD").Equals(1))
                { ShowAdButton.interactable = true; }
                else
                { ShowAdButton.interactable = false; ;}
            }
            //다른일
            else
            {
                ShowAdButton.interactable = true;
            }
        }
        //달 넘어감
        else if(!pastTime[1].Equals(current_time[1]))
        {
            ShowAdButton.interactable = true;
        }
        else
        {
           
        }

    }

    void ShowAdButtonClick()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }

        PlayerPrefs.SetString("TIME", System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm"));
        Debug.Log("don");
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                int rewardCoin = Random.Range(200, 520);
                PlayerPrefs.SetInt("COIN", PlayerPrefs.GetInt("COIN") + rewardCoin);
                PlayerPrefs.SetInt("DAYLYAD_REWARD", 2);
                ShowAdButton.interactable = false;
                GameObject.Find("ReceivePopup").GetComponent<ReceivePopup>().ReceivePopupData(rewardCoin);
                Debug.Log("1");
                break;
            case ShowResult.Skipped:
                Debug.Log("2");

                break;
            case ShowResult.Failed:
                Debug.Log("3");

                break;
        }
    }
     
     
}
