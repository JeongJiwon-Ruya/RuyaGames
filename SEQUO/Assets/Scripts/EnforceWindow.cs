using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnforceWindow : MonoBehaviour
{
    public Text SequoianLeaf;
    public Text SeasonMat;
    public Text FieldMat;
    public Text Coin;
    public Button EnforceButton;
    public GameObject[] Buttons;

    public int leaf_required, season_required, field_required, coin_required;
    public string seasonMat, fieldMat;

    public int EnforceTo;
    public string HeroName;

    // Start is called before the first frame update
    void Start()
    {
        EnforceButton.onClick.AddListener(EnforceButtonClick);

        MaterialRefresh();
        if (CanEnforce())
        {
            EnforceButton.gameObject.GetComponent<Image>().sprite = Buttons[0].GetComponent<SpriteRenderer>().sprite;
            EnforceButton.interactable = true;
        }
        else
        {
            EnforceButton.gameObject.GetComponent<Image>().sprite = Buttons[1].GetComponent<SpriteRenderer>().sprite;
        }
    }

    void EnforceButtonClick()
    {
        PlayerPrefs.SetInt("REINFORCE_SEQUOIAN_LEAF", PlayerPrefs.GetInt("REINFORCE_SEQUOIAN_LEAF") - leaf_required);
        PlayerPrefs.SetInt(seasonMat, PlayerPrefs.GetInt(seasonMat) - season_required);
        PlayerPrefs.SetInt(fieldMat, PlayerPrefs.GetInt(fieldMat) - field_required);
        PlayerPrefs.SetInt("COIN", PlayerPrefs.GetInt("COIN") - coin_required);
        PlayerPrefs.SetInt(HeroName + "_STAR", EnforceTo);

        SceneManager.LoadScene("HeroScene");
    }

    private void MaterialRefresh()
    {
        SequoianLeaf.text = PlayerPrefs.GetInt("REINFORCE_SEQUOIAN_LEAF").ToString() + "/" + leaf_required.ToString();
        SeasonMat.text = PlayerPrefs.GetInt(seasonMat).ToString() + "/" + season_required.ToString();
        FieldMat.text = PlayerPrefs.GetInt(fieldMat).ToString() + "/" + field_required.ToString();
        Coin.text = PlayerPrefs.GetInt("COIN").ToString() + "/" + coin_required.ToString();

    }

    private bool CanEnforce()
    {
        if((PlayerPrefs.GetInt("REINFORCE_SEQUOIAN_LEAF") >= leaf_required) && (PlayerPrefs.GetInt(seasonMat) >= season_required) && (PlayerPrefs.GetInt(fieldMat) >= field_required) && (PlayerPrefs.GetInt("COIN") >= coin_required))
        {
            return true;
        }
        return false;
    }

   
}
