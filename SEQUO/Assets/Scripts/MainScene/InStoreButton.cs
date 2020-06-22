using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InStoreButton : MonoBehaviour
{
    public Text count;
    Button ownButton;

    string flowerName;

    // Start is called before the first frame update
    void Start()
    {


        ownButton = GetComponent<Button>();
        string[] flowerNameS = name.Split('_');
        flowerName = flowerNameS[0];
        ownButton.onClick.AddListener(ApplyButton);
    }
    public void ApplyButton()
    {
        Season_Coordinate_Controller.Instance.ApplyFlower(flowerName);
    }
    private void Update()
    {
        count.text = PlayerPrefs.GetInt(flowerName + "_COUNT").ToString();
        
        if (int.Parse(count.text).Equals(0))
            ownButton.interactable = false;
        else
            ownButton.interactable = true;
    }
}
