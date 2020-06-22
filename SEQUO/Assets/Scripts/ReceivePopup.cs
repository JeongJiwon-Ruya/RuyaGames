using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceivePopup : MonoBehaviour
{
    Text own;
    private void Start()
    {
        own = GetComponent<Text>();
        own.text = "";
    }

    public void ReceivePopupData(int coin)
    {
        StartCoroutine(Popup(coin));
    }

    IEnumerator Popup(int coin)
    {
        own.text = coin.ToString() + "G 획득!";
        yield return new WaitForSeconds(2.0f);
        own.text = "";
    }
}
