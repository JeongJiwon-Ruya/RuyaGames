using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InShopButton : MonoBehaviour
{
    public Button BuyBtn;

    string FLOWER_NAME;

    public Text select;

    string NAME;

    Text cost;

    // Start is called before the first frame update
    void Start()
    {
        NAME = transform.Find("Name").GetComponent<Text>().text;

        cost = transform.GetComponentInChildren<Text>();

        GetComponent<Button>().onClick.AddListener(ButtonClicked);

        string[] flowerNameS = name.Split('_');
        FLOWER_NAME = flowerNameS[0];
    }


    void ButtonClicked()
    {
        select.text = NAME;

        if (PlayerPrefs.GetInt("COIN") >= int.Parse(cost.text))
        {
            BuyBtn.interactable = true;
            BuyBtn.GetComponent<PurchaseButton>().Set(FLOWER_NAME, int.Parse(cost.text));
        }
        else
        {
            BuyBtn.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
