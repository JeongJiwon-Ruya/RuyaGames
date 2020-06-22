using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialCount : MonoBehaviour
{
    public Text[] Mat;

    // Update is called once per frame
    void Update()
    {
        Mat[0].text = PlayerPrefs.GetInt("REINFORCE_FLOWERPETAL").ToString();
        Mat[1].text = PlayerPrefs.GetInt("REINFORCE_CLOVER").ToString();
        Mat[2].text = PlayerPrefs.GetInt("REINFORCE_GINKGO_LEAF").ToString();
        Mat[3].text = PlayerPrefs.GetInt("REINFORCE_ICE_CRYSTAL").ToString();
        Mat[4].text = PlayerPrefs.GetInt("REINFORCE_SEQUOIAN_LEAF",0).ToString();
        Mat[5].text = PlayerPrefs.GetInt("REINFORCE_LAVASTONE", 0).ToString();
        Mat[6].text = PlayerPrefs.GetInt("REINFORCE_VALLEYRUBBLE", 0).ToString();
        Mat[7].text = PlayerPrefs.GetInt("REINFORCE_ICE_TEARDROP", 0).ToString();
        Mat[8].text = PlayerPrefs.GetInt("REINFORCE_FAIRYS_FEATHER",0).ToString();

    }
}
