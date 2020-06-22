using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureBoxInit : MonoBehaviour
{
    List<string> BoxInit = null;
    public Button boxx;
    public GameObject RewardImg;
    public Text CoinCash;

    public Sprite open;

    int coincash = 0;

    private void Start()
    {
        BoxInit = new List<string>();

        if (PlayerPrefs.GetString("PLAYMODE").Equals("ADVENTURE"))
        {
            string difficulty = PlayerPrefs.GetString("DIFFICULTY");
            switch (PlayerPrefs.GetString("FIELD", "SKYVALLEY"))
            {
                case "SKYVALLEY":
                    switch (difficulty)
                    {
                        case "EASY":
                            for (int i = 0; i < 50; i++)
                            {
                                BoxInit.Add("COIN");
                                coincash = Random.Range(50, 100);
                            }
                            for (int i = 0; i < 40; i++)
                            {
                                BoxInit.Add("REINFORCE_SEQUOIAN_LEAF");
                            }
                            for (int i = 0; i < 2; i++)
                            {
                                BoxInit.Add("REINFORCE_VALLEYRUBBLE");
                            }
                            for (int i = 0; i < 8; i++)
                            {
                                BoxInit.Add("REINFORCE_LAVASTONE");
                            }
                            break;
                        case "NORMAL":
                            for (int i = 0; i < 40; i++)
                            {
                                BoxInit.Add("COIN");
                                coincash = Random.Range(100, 200);
                            }
                            for (int i = 0; i < 40; i++)
                            {
                                BoxInit.Add("REINFORCE_SEQUOIAN_LEAF");
                            }
                            for (int i = 0; i < 2; i++)
                            {
                                BoxInit.Add("REINFORCE_VALLEYRUBBLE");
                            }
                            for (int i = 0; i < 18; i++)
                            {
                                BoxInit.Add("REINFORCE_LAVASTONE");
                            }
                            break;
                        case "HARD":
                            for (int i = 0; i < 40; i++)
                            {
                                BoxInit.Add("COIN");
                                coincash = Random.Range(200, 350);
                            }
                            for (int i = 0; i < 30; i++)
                            {
                                BoxInit.Add("REINFORCE_SEQUOIAN_LEAF");
                            }
                            for (int i = 0; i < 3; i++)
                            {
                                BoxInit.Add("REINFORCE_VALLEYRUBBLE");
                            }
                            for (int i = 0; i < 27; i++)
                            {
                                BoxInit.Add("REINFORCE_LAVASTONE");
                            }
                            break;
                        case "INSANE":
                            for (int i = 0; i < 30; i++)
                            {
                                BoxInit.Add("COIN");
                                coincash = Random.Range(350, 500);
                            }
                            for (int i = 0; i < 30; i++)
                            {
                                BoxInit.Add("REINFORCE_SEQUOIAN_LEAF");
                            }
                            for (int i = 0; i < 2; i++)
                            {
                                BoxInit.Add("REINFORCE_VALLEYRUBBLE");
                            }
                            for (int i = 0; i < 38; i++)
                            {
                                BoxInit.Add("REINFORCE_LAVASTONE");
                            }
                            break;
                        case "HELL":
                            for (int i = 0; i < 30; i++)
                            {
                                BoxInit.Add("COIN");
                                coincash = Random.Range(500, 700);
                            }
                            for (int i = 0; i < 30; i++)
                            {
                                BoxInit.Add("REINFORCE_SEQUOIAN_LEAF");
                            }
                            for (int i = 0; i < 2; i++)
                            {
                                BoxInit.Add("REINFORCE_VALLEYRUBBLE");
                            }
                            for (int i = 0; i < 38; i++)
                            {
                                BoxInit.Add("REINFORCE_LAVASTONE");
                            }
                            break;
                    }
                    break;
                case "FIREFLYSWAMP":
                    switch (difficulty)
                    {
                        case "EASY":
                            for (int i = 0; i < 50; i++)
                            {
                                BoxInit.Add("COIN");
                                coincash = Random.Range(50, 100);
                            }
                            for (int i = 0; i < 45; i++)
                            {
                                BoxInit.Add("REINFORCE_SEQUOIAN_LEAF");
                            }
                            for (int i = 0; i < 5; i++)
                            {
                                BoxInit.Add("REINFORCE_FAIRYS_FEATHER");
                            }
                            break;
                        case "NORMAL":
                            for (int i = 0; i < 40; i++)
                            {
                                BoxInit.Add("COIN");
                                coincash = Random.Range(100, 200);
                            }
                            for (int i = 0; i < 40; i++)
                            {
                                BoxInit.Add("REINFORCE_SEQUOIAN_LEAF");
                            }
                            for (int i = 0; i < 20; i++)
                            {
                                BoxInit.Add("REINFORCE_FAIRYS_FEATHER");
                            }
                            break;
                        case "HARD":
                            for (int i = 0; i < 40; i++)
                            {
                                BoxInit.Add("COIN");
                                coincash = Random.Range(200, 350);
                            }
                            for (int i = 0; i < 30; i++)
                            {
                                BoxInit.Add("REINFORCE_SEQUOIAN_LEAF");
                            }
                            for (int i = 0; i < 30; i++)
                            {
                                BoxInit.Add("REINFORCE_FAIRYS_FEATHER");
                            }
                            break;
                        case "INSANE":
                            for (int i = 0; i < 30; i++)
                            {
                                BoxInit.Add("COIN");
                                coincash = Random.Range(350, 500);
                            }
                            for (int i = 0; i < 30; i++)
                            {
                                BoxInit.Add("REINFORCE_SEQUOIAN_LEAF");
                            }
                            for (int i = 0; i < 40; i++)
                            {
                                BoxInit.Add("REINFORCE_FAIRYS_FEATHER");
                            }
                            break;
                        case "HELL":
                            for (int i = 0; i < 30; i++)
                            {
                                BoxInit.Add("COIN");
                                coincash = Random.Range(500, 700);
                            }
                            for (int i = 0; i < 30; i++)
                            {
                                BoxInit.Add("REINFORCE_SEQUOIAN_LEAF");
                            }
                            for (int i = 0; i < 40; i++)
                            {
                                BoxInit.Add("REINFORCE_FAIRYS_FEATHER");
                            }
                            break;
                    }
                    break;
                case "CAVE":
                    switch (difficulty)
                    {
                        case "EASY":
                            for (int i = 0; i < 50; i++)
                            {
                                BoxInit.Add("COIN");
                                coincash = Random.Range(50, 100);
                            }
                            for (int i = 0; i < 40; i++)
                            {
                                BoxInit.Add("REINFORCE_SEQUOIAN_LEAF");
                            }
                            for (int i = 0; i < 10; i++)
                            {
                                BoxInit.Add("REINFORCE_ICE_TEARDROP");
                            }
                            break;
                        case "NORMAL":
                            for (int i = 0; i < 40; i++)
                            {
                                BoxInit.Add("COIN");
                                coincash = Random.Range(100, 200);
                            }
                            for (int i = 0; i < 40; i++)
                            {
                                BoxInit.Add("REINFORCE_SEQUOIAN_LEAF");
                            }
                            for (int i = 0; i < 20; i++)
                            {
                                BoxInit.Add("REINFORCE_ICE_TEARDROP");
                            }
                            break;
                        case "HARD":
                            for (int i = 0; i < 40; i++)
                            {
                                BoxInit.Add("COIN");
                                coincash = Random.Range(200, 350);
                            }
                            for (int i = 0; i < 30; i++)
                            {
                                BoxInit.Add("REINFORCE_SEQUOIAN_LEAF");
                            }
                            for (int i = 0; i < 30; i++)
                            {
                                BoxInit.Add("REINFORCE_ICE_TEARDROP");
                            }
                            break;
                        case "INSANE":
                            for (int i = 0; i < 30; i++)
                            {
                                BoxInit.Add("COIN");
                                coincash = Random.Range(350, 500);
                            }
                            for (int i = 0; i < 30; i++)
                            {
                                BoxInit.Add("REINFORCE_SEQUOIAN_LEAF");
                            }
                            for (int i = 0; i < 40; i++)
                            {
                                BoxInit.Add("REINFORCE_ICE_TEARDROP");
                            }
                            break;
                        case "HELL":
                            for (int i = 0; i < 30; i++)
                            {
                                BoxInit.Add("COIN");
                                coincash = Random.Range(500, 700);
                            }
                            for (int i = 0; i < 30; i++)
                            {
                                BoxInit.Add("REINFORCE_SEQUOIAN_LEAF");
                            }
                            for (int i = 0; i < 40; i++)
                            {
                                BoxInit.Add("REINFORCE_ICE_TEARDROP");
                            }
                            break;
                    }
                    break;

            }

        }
        else
        {
            for (int i = 0; i < 100; i++)
            {
                BoxInit.Add("COIN");
                coincash = Random.Range(20, 100);
            }
        }

    }
    public string Open_Box()
    {

        int hand = Random.Range(0, 100);    
        return BoxInit[hand];
    }

    public void BoxOpenClicked()
    {
        gameObject.GetComponent<Image>().sprite = open;

        SoundEffectController.Instance.BoxOpenSound();

        string reward = Open_Box();
        RewardImg.GetComponent<Image>().enabled = true;
        RewardImg.GetComponent<Image>().sprite = Resources.Load(reward, typeof(Sprite)) as Sprite;

        if (reward.Equals("COIN"))
        {
            CoinCash.text = coincash.ToString();
            GameObject.Find("TreasureBoxOpenPopup").GetComponent<TreasureController>().CollectReward("COIN", coincash);
        //    PlayerPrefs.SetInt("COIN", PlayerPrefs.GetInt("COIN") + coincash);  //**
        }
        else
        {
            GameObject.Find("TreasureBoxOpenPopup").GetComponent<TreasureController>().CollectReward(reward, 1);
         //   PlayerPrefs.SetInt(reward, PlayerPrefs.GetInt(reward, 0) + 1);  //**
        }


        boxx.interactable = false;


    }
}
