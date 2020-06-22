using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroButton : MonoBehaviour
{
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        ENFORCE_GENERAL_CONTROLLER.Instance.ReceiveIndex(index);
    }
}
