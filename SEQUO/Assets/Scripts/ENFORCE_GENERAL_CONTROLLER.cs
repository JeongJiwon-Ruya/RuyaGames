using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ENFORCE_GENERAL_CONTROLLER : MonoBehaviour
{
    protected static ENFORCE_GENERAL_CONTROLLER instance = null;
    public static ENFORCE_GENERAL_CONTROLLER Instance
    {
        get
        {
            instance = FindObjectOfType(typeof(ENFORCE_GENERAL_CONTROLLER)) as ENFORCE_GENERAL_CONTROLLER;

            if (instance == null)
            {
                instance = new GameObject("@" + typeof(ENFORCE_GENERAL_CONTROLLER).ToString(), typeof(ENFORCE_GENERAL_CONTROLLER)).AddComponent<ENFORCE_GENERAL_CONTROLLER>();
                DontDestroyOnLoad(instance);
            }
            return instance;
        }
    }

    public GameObject HeroSelectedImage;

    public GameObject EnforceWindow;
    public GameObject Heifetz_Window;
    public GameObject Hyacinth_Window;
    public GameObject Aria_Window;

    public GameObject Heifetz_Info;
    public GameObject Hyacinth_Info;
    public GameObject Aria_Info;

    public GameObject Heifetz_Enforce_To1;
    public GameObject Heifetz_Enforce_To2;
    public GameObject Heifetz_Enforce_To3;
    public GameObject Hyacinth_Enforce_To1;
    public GameObject Hyacinth_Enforce_To2;
    public GameObject Hyacinth_Enforce_To3;
    public GameObject Aria_Enforce_To1;
    public GameObject Aria_Enforce_To2;
    public GameObject Aria_Enforce_To3;

    public GameObject HeifetzStar;
    public GameObject HyacinthStar;
    public GameObject AriaStar;

    public GameObject Star_left;

    public GameObject[] starImg;

    public GameObject PurchasePanel;
    public GameObject Hyacinth_PurchaseButton;
    public GameObject Aria_PurchaseButton;

    private void Start()
    {


        StarRefresh();

    }


    public void StarRefresh()
    {
        HeifetzStar.GetComponent<Image>().sprite = starImg[PlayerPrefs.GetInt("HEIFETZ_STAR")].GetComponent<SpriteRenderer>().sprite;
        HyacinthStar.GetComponent<Image>().sprite = starImg[PlayerPrefs.GetInt("HYACINTH_STAR")].GetComponent<SpriteRenderer>().sprite;
        AriaStar.GetComponent<Image>().sprite = starImg[PlayerPrefs.GetInt("ARIA_STAR")].GetComponent<SpriteRenderer>().sprite;
    }
    public void ReceiveIndex(int heroIndex) // 0= heifetz 1=hyacinth 2=aria
    {
        switch (heroIndex)
        {
            case 0:

                PurchasePanel.SetActive(false);

                Heifetz_Info.SetActive(true);
                Hyacinth_Info.SetActive(false);
                Aria_Info.SetActive(false);

                Star_left.GetComponent<Image>().sprite = starImg[PlayerPrefs.GetInt("HEIFETZ_STAR")].GetComponent<SpriteRenderer>().sprite;

                Heifetz_Window.SetActive(true);
                Hyacinth_Window.SetActive(false);
                Aria_Window.SetActive(false);

                HeroSelectedImage.GetComponent<Image>().sprite = Resources.Load("영웅_검", typeof(Sprite)) as Sprite;
                switch (PlayerPrefs.GetInt("HEIFETZ_STAR"))
                {
                    case 0:
                        Heifetz_Enforce_To1.SetActive(true);
                        break;
                    case 1:
                        Heifetz_Enforce_To2.SetActive(true);
                        break;
                    case 2:
                        Heifetz_Enforce_To3.SetActive(true);
                        break;
                }
                break;
            case 1:
                if (PlayerPrefs.GetInt("IsHYACINTH_LOCK").Equals(0))
                {
                    HeroSelectedImage.GetComponent<Image>().sprite = Resources.Load("영웅_마법", typeof(Sprite)) as Sprite;
                    PurchasePanel.SetActive(true);
                    Hyacinth_PurchaseButton.SetActive(true);
                    Aria_PurchaseButton.SetActive(false);
                }
                else
                {
                    Heifetz_Info.SetActive(false);
                    Hyacinth_Info.SetActive(true);
                    Aria_Info.SetActive(false);
                    PurchasePanel.SetActive(false);
                    Star_left.GetComponent<Image>().sprite = starImg[PlayerPrefs.GetInt("HYACINTH_STAR")].GetComponent<SpriteRenderer>().sprite;

                    Heifetz_Window.SetActive(false);
                    Hyacinth_Window.SetActive(true);
                    Aria_Window.SetActive(false);

                    HeroSelectedImage.GetComponent<Image>().sprite = Resources.Load("영웅_마법", typeof(Sprite)) as Sprite;
                    switch (PlayerPrefs.GetInt("HYACINTH_STAR"))
                    {
                        case 0:
                            Hyacinth_Enforce_To1.SetActive(true);
                            break;
                        case 1:
                            Hyacinth_Enforce_To2.SetActive(true);
                            break;
                        case 2:
                            Hyacinth_Enforce_To3.SetActive(true);
                            break;
                    }
                }

                break;
            case 2:
                if (PlayerPrefs.GetInt("IsARIA_LOCK").Equals(0))
                {
                    HeroSelectedImage.GetComponent<Image>().sprite = Resources.Load("영웅_화살", typeof(Sprite)) as Sprite;
                    PurchasePanel.SetActive(true);
                    Hyacinth_PurchaseButton.SetActive(false);
                    Aria_PurchaseButton.SetActive(true);
                }
                else
                {
                    Heifetz_Info.SetActive(false);
                    Hyacinth_Info.SetActive(false);
                    Aria_Info.SetActive(true);
                    PurchasePanel.SetActive(false);
                    Star_left.GetComponent<Image>().sprite = starImg[PlayerPrefs.GetInt("ARIA_STAR")].GetComponent<SpriteRenderer>().sprite;

                    Heifetz_Window.SetActive(false);
                    Hyacinth_Window.SetActive(false);
                    Aria_Window.SetActive(true);

                    HeroSelectedImage.GetComponent<Image>().sprite = Resources.Load("영웅_화살", typeof(Sprite)) as Sprite;
                    switch (PlayerPrefs.GetInt("ARIA_STAR"))
                    {
                        case 0:
                            Aria_Enforce_To1.SetActive(true);
                            break;
                        case 1:
                            Aria_Enforce_To2.SetActive(true);
                            break;
                        case 2:
                            Aria_Enforce_To3.SetActive(true);
                            break;
                    }
                }
                break;

        }
    }

}
