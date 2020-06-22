using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseConfirm : MonoBehaviour
{
    Button confirmButton;
    public string identity;
    public GameObject PurchaseCompletePoup;
    public GameObject PurchaseFailPopup;
    
    // Start is called before the first frame update
    void Start()
    {
        confirmButton = GetComponent<Button>();
        confirmButton.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        Debug.Log(identity);

        if(PlayerPrefs.GetInt("COIN") >= 7000)
        {
            PlayerPrefs.SetInt("COIN", PlayerPrefs.GetInt("COIN") - 7000);
            PlayerPrefs.SetInt("Is" + identity + "_LOCK", 1);
            PurchaseCompletePoup.SetActive(true);
        }
        else
        {
            PurchaseFailPopup.SetActive(true);
        }
    }

}
