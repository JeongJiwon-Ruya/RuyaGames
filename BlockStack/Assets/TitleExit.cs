
using UnityEngine;
using UnityEngine.UI;

public class TitleExit : MonoBehaviour
{

    public GameObject t;

    int ClickCount = 0;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickCount++;
            if (!IsInvoking("DoubleClick"))
            {
                Invoke("DoubleClick", 2.0f);

            }

            t.SetActive(true);

        }
        else if (ClickCount == 2)
        {
            CancelInvoke("DoubleClick");
            Application.Quit();
        }

    }

    void DoubleClick()
    {
        ClickCount = 0;
        t.SetActive(false);
    }

}
