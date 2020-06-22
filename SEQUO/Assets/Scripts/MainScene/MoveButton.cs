using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour
{
    GameObject SFXController;

    public GameObject downMenu;
    private bool buttonMoving = false;

    private void Start()
    {
        Time.timeScale = 1f;
        SFXController = GameObject.Find("SFXController");
    }
    bool isMute()
    {
        if (PlayerPrefs.GetInt("MUTE").Equals(0))
            return false;
        else
            return true;
    }
    public void JustPlaySound()
    {
        if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }
    }

    public void HeroButtonClicked()
    {
        SceneManager.LoadScene("HeroScene"); if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }
    }

    public void BookButtonClicked()
    {
        SceneManager.LoadScene("BookScene");
        if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }

    }

    public void ForestButtonClicked()
    {
        StartCoroutine(DownMenuDown());


    }

    public void ForestUpButtonClicked()
    {
        StartCoroutine(UpMenuDown()); if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }

    }

    public GameObject homeBtn;
    public Button forBtn;
    //17 ~ -53
    IEnumerator DownMenuDown()
    {
        if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }

        buttonMoving = true;

        Vector3 comp = new Vector3(downMenu.transform.localPosition.x, -775f, 0f);

        while(downMenu.transform.localPosition.y >= -775f)
        {
            float moveFloat = Time.deltaTime * 2f;
            downMenu.transform.localPosition = Vector3.Lerp(downMenu.transform.localPosition, comp, moveFloat);
            yield return null;
            if (downMenu.transform.localPosition.y <= -765f)
                break;
        }
        StopCoroutine(DownMenuDown());
        buttonMoving = false;
        downMenu.transform.localPosition = new Vector3((int)(downMenu.transform.localPosition.x), (int)(downMenu.transform.localPosition.y), (int)(downMenu.transform.localPosition.z));
        homeBtn.SetActive(true);

         yield return null;
    }

    public Button GameStart;

    IEnumerator UpMenuDown()
    {
        if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }
        GameStart.interactable = false;

        buttonMoving = true;

        forBtn.interactable = false;

        Vector3 comp = new Vector3(downMenu.transform.localPosition.x, -436f, 0) ;
        while (downMenu.transform.localPosition.y <= -476f)
        {
            float moveFloat = Time.deltaTime * 2f;
            downMenu.transform.localPosition = Vector3.Lerp(downMenu.transform.localPosition, comp, moveFloat);
            yield return null;
            if (downMenu.transform.localPosition.y >= -476f)
            {
                forBtn.interactable = true;
                break;
            }
        }
        StopCoroutine("UpMenuDown");
        buttonMoving = false;
        downMenu.transform.localPosition = new Vector3((int)(downMenu.transform.localPosition.x), (int)(downMenu.transform.localPosition.y), (int)(downMenu.transform.localPosition.z));

        GameStart.interactable = true;

        yield return null;
    }

   

    public void GameStartButtonClicked()
    {
        SceneManager.LoadScene("GameSelectScene");
        if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }

    }

    public void AdventureButtonClicked()
    {
        if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }
        PlayerPrefs.SetString("PLAYMODE", "ADVENTURE");
        SceneManager.LoadScene("AdventureScene");
    }

    public void InfinityButtonClicked()
    {
        if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }
        PlayerPrefs.SetString("PLAYMODE", "INFINITY");
        SceneManager.LoadScene("HeroSelectScene");
    }


    public void GoToHomeButtonClicked()
    {
        if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }
        SceneManager.LoadScene("MainScene");
    }

    public void RedoButton()
    {
        if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }
        SceneManager.LoadScene("GameSelectScene");
    }

    public void RedoButton_Difficulty()
    {
        if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }
        SceneManager.LoadScene("AdventureScene");
    }

    public void FieldSelectButtonClicked()
    {
        if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }
        PlayerPrefs.SetString("FIELD", "SKYVALLEY");
        SceneManager.LoadScene("DifficultySelectScene");
    }

    public void EasyButtonClicked()
    {
        if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }
        PlayerPrefs.SetString("DIFFICULTY", "EASY");
        SceneManager.LoadScene("HeroSelectScene");
    }
    public void NormalButtonClicked()
    {
        if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }
        PlayerPrefs.SetString("DIFFICULTY", "NORMAL");
        SceneManager.LoadScene("HeroSelectScene");
        //nm;
    }
    public void HardButtonClicked()
    {
        if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }
        PlayerPrefs.SetString("DIFFICULTY", "HARD");
        SceneManager.LoadScene("HeroSelectScene");
        //hd;
    }
    public void InsaneButtonClicked()
    {
        if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }
        PlayerPrefs.SetString("DIFFICULTY", "INSANE");
        SceneManager.LoadScene("HeroSelectScene");
        //ins;
    }
    public void HellButtonClicked()
    {
        if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }
        PlayerPrefs.SetString("DIFFICULTY", "HELL");
        SceneManager.LoadScene("HeroSelectScene");
        //hell;
    }

    public void RedoButton_HeroSelect()
    {
        if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }
        if (PlayerPrefs.GetString("PLAYMODE").Equals("ADVENTURE"))
        {
            SceneManager.LoadScene("DifficultySelectScene");
        }
        else
        {
            SceneManager.LoadScene("GameSelectScene");
        }
    }

    public void GotoMainButtonClicked()
    {
        if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }
        SceneManager.LoadScene("MainScene");
    }

    public void IntroToMain()
    {
        LoadingSceneManager.LoadScene("MainScene");
    }


    public void GameStartButtonClicked_InConfirm()
    {
        if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }
        LoadingSceneManager.LoadScene("GameScene");
    }

    public void ChooljeonClicked()
    {
        if (!isMute())
        {
            SFXController.GetComponent<NonGameSFX>().BtnClick();
        }
        SceneManager.LoadScene("StartConfirmScene");
    }
}
