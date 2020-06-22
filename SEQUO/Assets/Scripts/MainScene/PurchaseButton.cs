using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseButton : MonoBehaviour
{
    public GameObject SFX;

    string targetFlower;
    int cost;

    Button own;
    private void Start()
    {
        own = GetComponent<Button>();
    }

    public void Set(string flowerName, int _cost)
    {
        targetFlower = flowerName + "_COUNT";
        cost = _cost;
    }

    public void Purchase()
    {
        PlayerPrefs.SetInt("COIN", PlayerPrefs.GetInt("COIN") - cost);
        PlayerPrefs.SetInt(targetFlower, PlayerPrefs.GetInt(targetFlower) + 1);
        SFX.GetComponent<NonGameSFX>().PlayShop();
    }

    private void Update()
    {
        if (cost > PlayerPrefs.GetInt("COIN"))
        {
            own.interactable = false;
        }
    }
}
