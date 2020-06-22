using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIXCHARTPOPUP : MonoBehaviour
{
    public void ButtonClick()
    {
        Time.timeScale = 0f;
    }

    public void XButtonClick()
    {
        Time.timeScale = 1f;
    }
}
