using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(BtnClilck);
    }

    void BtnClilck()
    {
        DictionaryController.Instance.ReceiveUnitInfo(index);
    }
}
