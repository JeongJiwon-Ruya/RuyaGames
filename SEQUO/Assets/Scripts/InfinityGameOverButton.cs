using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfinityGameOverButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     //   GetComponent<Button>().onClick.AddListener(onbtnClick);
    }

void onbtnClick()
    {
        LoadingSceneManager.LoadScene("MainScene");
        BGMController.Instance.StartBgm();
    }
}
