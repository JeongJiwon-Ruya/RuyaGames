using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    SFX _sfx;
    private int sc = 0;

    private void Start()
    {
        _sfx = GameObject.Find("SFX").GetComponent<SFX>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GameOver"))
            GameObject.Find("GameController").GetComponent<GameController>().GameOverPopupShowing();
        else if (collision.gameObject.CompareTag("Block"))
        {
            if(sc < 2)
            {
                _sfx.PlayBlockStackSound();
                sc++;
            }
        }
    }



}
