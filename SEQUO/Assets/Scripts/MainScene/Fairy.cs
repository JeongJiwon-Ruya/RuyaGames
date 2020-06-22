using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fairy : MonoBehaviour
{
    public GameObject[] Rewards;


    public GameObject OnReward;

    bool isCoin;
    //0=코인    1=봄재료 2=여름재료 3=가을재료 4=겨울재료

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ButnClick);    
    }

    private void ButnClick()
    {
        GameObject.Find("SFXController").GetComponent<NonGameSFX>().FairyClick();
        gameObject.GetComponent<Button>().interactable = false;

        int random = Random.Range(0,100);
        if((0 <= random) && (random < 85))
        {
            OnReward.GetComponent<Image>().sprite = Rewards[0].GetComponent<SpriteRenderer>().sprite;
            isCoin = true;
            //얼마받을지입력
        }
        else
        {
            switch (Season_Coordinate_Controller.Instance.season_Num)
            {
                case 0:
                    OnReward.GetComponent<Image>().sprite = Rewards[1].GetComponent<SpriteRenderer>().sprite;
                    break;
                case 1:
                    OnReward.GetComponent<Image>().sprite = Rewards[2].GetComponent<SpriteRenderer>().sprite;
                    break;
                case 2:
                    OnReward.GetComponent<Image>().sprite = Rewards[3].GetComponent<SpriteRenderer>().sprite;
                    break;
                case 3:
                    OnReward.GetComponent<Image>().sprite = Rewards[4].GetComponent<SpriteRenderer>().sprite;
                    break;
                case 4: //default
                    OnReward.GetComponent<Image>().sprite = Rewards[0].GetComponent<SpriteRenderer>().sprite;
                    isCoin = true;
                    break;
            }
        }

        StartCoroutine(StartAnim());

    }

    IEnumerator StartAnim()
    {
        OnReward.SetActive(true);
        OnReward.GetComponent<RewardMoving>().OutParent();
        if (isCoin)
        {
            int randCo = Random.Range(10,40);
            PlayerPrefs.SetInt("COIN", PlayerPrefs.GetInt("COIN") + randCo);
        }
        else
        {
            PlayerPrefs.SetInt(OnReward.GetComponent<Image>().sprite.name, PlayerPrefs.GetInt(OnReward.GetComponent<Image>().sprite.name) + 1);


        }

        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }
}
