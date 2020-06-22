using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;

public class TitleSceneManager : MonoBehaviour
{
    private int MAX_SKIN_VALUE = 4;

    public Text PopupText;

    public Text HighScoreText;
    public Button GameStartButton;

    public Button LeftButton;
    public Button RightButton;
    public Image SkinShowing;
    public Text Coin_Text;
    public Button ConfirmButton;
    public GameObject BuyButton;

    public Image WallPaper;
    public GameObject[] WallSkin;

    private int currentSkinIndex;
    public GameObject[] SkinShows;

    private void Awake()
    {
        Screen.SetResolution(Screen.width, (Screen.width * 19) / 9, true);
            
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("SKIN_UNLOCK_0").Equals(0))
            PlayerPrefs.SetInt("SKIN_UNLOCK_0", 1);


        currentSkinIndex= PlayerPrefs.GetInt("SKIN");

        RefreshSkin();
        WallChange();

        Coin_Text.text = PlayerPrefs.GetInt("COIN").ToString();

        HighScoreText.text = PlayerPrefs.GetInt("HIGHSCORE").ToString();
        GameStartButton.onClick.AddListener(GameStartButtonClick);
    }

    private void GameStartButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void RefreshSkin()
    {
        if (PlayerPrefs.GetInt("SKIN_UNLOCK_" + currentSkinIndex).Equals(1))
        {
            ConfirmButton.interactable = true;
            BuyButton.SetActive(false);
        }
        else
        {
            ConfirmButton.interactable = false;
            BuyButton.SetActive(true);
        }
        SkinShowing.material = SkinShows[currentSkinIndex].GetComponent<Image>().material;
    }

    public void LeftButtonClick()
    {
        if (currentSkinIndex > 0)
            currentSkinIndex--;
        else
            currentSkinIndex = MAX_SKIN_VALUE;

        RefreshSkin();
        WallChange();
    }

    public void RightButtonClick()
    {
        if (currentSkinIndex < MAX_SKIN_VALUE)
            currentSkinIndex++;
        else
            currentSkinIndex = 0;

        RefreshSkin();
        WallChange();
    }

    public void ConfirmButtonClick()
    {
        WallChange();
        PlayerPrefs.SetInt("SKIN", currentSkinIndex);
        StartCoroutine(TextPopupAnim("Apply!",true));
    }

    public void WallChange()
    {
        WallPaper.material = WallSkin[currentSkinIndex].GetComponent<Image>().material;
    }

    public void BuyButtonClick()
    {
        int currentCoin = PlayerPrefs.GetInt("COIN");
        if(currentCoin >= 50)
        {
            PlayerPrefs.SetInt("COIN", currentCoin - 50);
            PlayerPrefs.SetInt("SKIN_UNLOCK_" + currentSkinIndex, 1);
            BuyButton.SetActive(false);
            ConfirmButton.interactable = true;
            Coin_Text.text = PlayerPrefs.GetInt("COIN").ToString();
            StartCoroutine(TextPopupAnim("Purchase!",false));
        }
        else
        {
            StartCoroutine(TextPopupAnim("Not enough coin.",false));
        }
    }

    public GameObject CheckIcon;

    IEnumerator TextPopupAnim(string text, bool own)
    {
        PopupText.text = text;
        PopupText.gameObject.SetActive(true);

        if (own)
            CheckIcon.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        CheckIcon.SetActive(false);

        PopupText.gameObject.SetActive(false);
        PopupText.text = "";
    }


    public void RankButtonClick()
    {
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(AuthenticateHandler);
    }

    void AuthenticateHandler(bool isSuccess)
    {
        if (isSuccess)
        {
            float highScore = PlayerPrefs.GetInt("HIGHSCORE");
            Social.ReportScore((long)highScore, "CgkIjoOtpeEJEAIQAg", (bool success) =>
             {
                 if (success)
                 {
                     PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIjoOtpeEJEAIQAg");
                 }
                 else
                 {
                     Debug.Log("load highscore fail");
                 }
             });
        }
        else
        {
            Debug.Log("login Fail");
        }
    }
}
