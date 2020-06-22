using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public static string nextScene;
   

    [SerializeField]
    Image progressBar;

    public Text LoadingText;
    public GameObject LoadingImage_Intro;
    public GameObject LoadingImage_GameStart;

    private void Awake()
    {
        Screen.SetResolution(2280, 1080, true);
    }

    private void Start()
    {
        StartCoroutine(LoadScene());
        Time.timeScale = 1f;
    }

    string nextSceneName;
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadScene()
    {
        
        if (nextScene.Equals("GameScene"))
        {
            LoadingImage_GameStart.gameObject.SetActive(true);
            LoadingImage_Intro.SetActive(false);
        }
        else
        {
            LoadingImage_GameStart.gameObject.SetActive(false);
            LoadingImage_Intro.SetActive(true);
        }
        yield return null;
      

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime;
            if (op.progress >= 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);

                if (progressBar.fillAmount == 1.0f)
                    op.allowSceneActivation = true;
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
        }
    }
}
