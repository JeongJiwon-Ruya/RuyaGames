using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ACHIEVEMENT_REWARD : MonoBehaviour
{
    public string what_achieve;
    public Text rewardCoin;
    public Button receiveReward;    //기본 상태는 비활성


    void Start()
    {
        receiveReward.onClick.AddListener(ReceiveButtonClick);

        if (PlayerPrefs.GetInt(what_achieve).Equals(1))
        {
            receiveReward.gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt(what_achieve).Equals(2))
        {
            receiveReward.gameObject.SetActive(true);
            receiveReward.interactable = false;
        }
    }

    void ReceiveButtonClick()
    {
        string[] rew = rewardCoin.text.Split('G');
        int ard = int.Parse(rew[0]);

        GameObject.Find("ReceivePopup").GetComponent<ReceivePopup>().ReceivePopupData(ard);

        PlayerPrefs.SetInt("COIN", PlayerPrefs.GetInt("COIN") +ard);
        PlayerPrefs.SetInt(what_achieve, 2);

        receiveReward.interactable = false;
    }


}
