using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeRecorder : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {

            if (Input.GetKey(KeyCode.Escape))
            {
                if (SceneManager.GetActiveScene().name.Equals("GameScene"))
                {
                    GameObject.Find("MainCamera").GetComponent<setResolution>().Pause();
                }
                else
                {
                    Application.Quit();
                }
            }
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("TIME", System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm"));
    }

    
}
