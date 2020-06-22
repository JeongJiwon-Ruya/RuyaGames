using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Offer : MonoBehaviour
{
    public GameController gameController;

    public Text Block;
    public string _name;
    public int _index;
    public bool _coin;
    public GameObject CoinImg;

    public Image ShowBlock;

    public Image[] Blocks;

    public void SetInfo(string name, int index, bool coin)
    {
        _name = name;
        _index = index;

        //   Block.text = name;

        ShowBlock.sprite = Blocks[index].sprite;

        _coin = coin;
        if (coin)
            CoinImg.SetActive(true);
        
        else
            CoinImg.SetActive(false);
    }

    public void ButtonClick()
    {
        gameController.ReceiveOffer(_index, _coin);
    }

}
