using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FieldSelectController : MonoBehaviour
{
    int state = 0;
    public GameObject[] FieldImg;
    public GameObject[] Point;
    private void Update()
    {
        switch (state)
        {
            case 0:
                FieldImg[0].SetActive(true);
                FieldImg[1].SetActive(false);
                FieldImg[2].SetActive(false);
                Point[0].SetActive(true);
                Point[1].SetActive(false);
                Point[2].SetActive(false);
                break;
            case 1:
                FieldImg[0].SetActive(false);
                FieldImg[1].SetActive(true);
                FieldImg[2].SetActive(false);
                Point[0].SetActive(false);
                Point[1].SetActive(true);
                Point[2].SetActive(false);
                break;
            case 2:
                FieldImg[0].SetActive(false);
                FieldImg[1].SetActive(false);
                FieldImg[2].SetActive(true);
                Point[0].SetActive(false);
                Point[1].SetActive(false);
                Point[2].SetActive(true);
                break;
        }
    }

    public void RightButtonClick()
    {
        if (state.Equals(2))
            state = 0;
        else
            state++;
    }
    public void LeftButtonClick()
    {
        if (state.Equals(0))
            state = 2;
        else
            state--;
    }

    public void ConfirmButtonClick()
    {
        switch (state)
        {
            case 0:
                PlayerPrefs.SetString("FIELD", "SKYVALLEY");
                break;
            case 1:
                PlayerPrefs.SetString("FIELD", "FIREFLYSWAMP");
                break;
            case 2:
                PlayerPrefs.SetString("FIELD", "CAVE");
                break;
        }

        SceneManager.LoadScene("DifficultySelectScene");
    }

}
