using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class setResolution : MonoBehaviour
{
    
    private bool isPaused;
    public GameObject PausedWindow;

    private void Start()
    {
        Screen.SetResolution(2280, 1080, true);
        Application.targetFrameRate = 60;
    }

    public void TestButton()
    {
        Time.timeScale = 0f;
        PausedWindow.SetActive(true);
    }

    public void RestartGame()
    {
        PausedWindow.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GotoMain()
    {
        if(PlayerPrefs.GetInt("MUTE").Equals(0))
            BGMController.Instance.StartBgm();
        SceneManager.LoadScene("MainScene");
    }

    public void Pause()
    {
        PausedWindow.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

   

    }

  
