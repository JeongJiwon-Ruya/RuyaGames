using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeroSelectButtonController : MonoBehaviour
{
    public GameObject SelectedRed;
    public GameObject[] Heros;
    public Text HeroName;

    public GameObject Hyacinth_Lock;
    public GameObject Aria_Lock;

    private void Start()
    {
        if (PlayerPrefs.GetInt("IsHYACINTH_LOCK").Equals(0))
            Hyacinth_Lock.SetActive(true);
        else
            Hyacinth_Lock.SetActive(false);

        if (PlayerPrefs.GetInt("IsARIA_LOCK").Equals(0))
            Aria_Lock.SetActive(true);
        else
            Aria_Lock.SetActive(false);
    }

    public void Heifetz_Click()
    {
        SelectedRed.transform.localPosition = new Vector3(-350f, 0f, 0f);
        HeroName.text = "하이페츠";
        Heros[0].SetActive(true);
        Heros[1].SetActive(false);
        Heros[2].SetActive(false);
    }
    public void Hyacinth_Click()
    {
        SelectedRed.transform.localPosition = new Vector3(0f, 0f, 0f);
        HeroName.text = "히아신스";
        Heros[0].SetActive(false);
        Heros[1].SetActive(true);
        Heros[2].SetActive(false);
    }
    public void Aria_Click()
    {
        SelectedRed.transform.localPosition = new Vector3(350f, 0f, 0f);
        HeroName.text = "아리아";
        Heros[0].SetActive(false);
        Heros[1].SetActive(false);
        Heros[2].SetActive(true);
    }

    public void GoNext_Click()
    {
        switch (SelectedRed.transform.localPosition.x)
        {
            case -350f:
                PlayerPrefs.SetString("HERO_SELECTED", "HEIFETZ");
                break;
            case 0f:
                PlayerPrefs.SetString("HERO_SELECTED", "HYACINTH");
                break;
            case 350f:
                PlayerPrefs.SetString("HERO_SELECTED", "ARIA");
                break;
            default:
                PlayerPrefs.SetString("HERO_SELECTED", "HEIFETZ");
                break;
        }
        SceneManager.LoadScene("StartConfirmScene");
    }
}
