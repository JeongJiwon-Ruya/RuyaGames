using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class TreasureController : MonoBehaviour
{
    private int box_collected;
    public GameObject BoxPanel;
    public GameObject TreasureBox;

    private int collectCoin;
    private List<string> collectMaterials;

    public AdmobAdManager admob;

    void Start()
    {
        collectMaterials = new List<string>();

        box_collected = MainController.Instance.treasureboxCount;

        for(int i = 0;i < box_collected; i++)
        {
            GameObject trb = (GameObject)Instantiate(TreasureBox) as GameObject;
            trb.transform.SetParent(BoxPanel.transform);
        }
    }

    public void CollectReward(string name, int coin)
    {
        if (name.Equals("COIN"))
        {
            collectCoin += coin;
        }
        else
        {
            collectMaterials.Add(name);
        }
    }

    public void GetWithoutAd()
    {
        PlayerPrefs.SetInt("COIN", PlayerPrefs.GetInt("COIN") + collectCoin);
        for(int i = 0; i < collectMaterials.Count; i++)
        {
            PlayerPrefs.SetInt(collectMaterials[i], PlayerPrefs.GetInt(collectMaterials[i]) + 1);
        }
        if (PlayerPrefs.GetInt("MUTE").Equals(0))
        {
            BGMController.Instance.StartBgm();
        }
        LoadingSceneManager.LoadScene("MainScene");
    }

    public void GetWithAd()
    {
        ShowRewardedAd();
    }
    IEnumerator GoMain()
    {
        BGMController.Instance.StartBgm();
        LoadingSceneManager.LoadScene("MainScene");
        yield return null;
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }


    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");

                PlayerPrefs.SetInt("COIN", PlayerPrefs.GetInt("COIN") + (collectCoin*2));
                for (int i = 0; i < collectMaterials.Count; i++)
                {
                    PlayerPrefs.SetInt(collectMaterials[i], PlayerPrefs.GetInt(collectMaterials[i]) + 2);
                }
                StartCoroutine(GoMain());

                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                GetWithoutAd();
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                GetWithoutAd();
                break;
        }
    }
}
