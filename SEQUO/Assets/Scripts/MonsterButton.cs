using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterButton : MonoBehaviour
{
    public int index;


    void Start()
    {
        GetComponent<Button>().onClick.AddListener(BtnClilck);

    }

    void BtnClilck()
    {
        DictionaryController.Instance.ReceiveMonsterInfo(index);
    }
}
