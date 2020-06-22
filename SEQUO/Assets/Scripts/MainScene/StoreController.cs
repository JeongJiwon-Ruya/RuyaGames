using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    public GameObject[] StoreButtonArray;
    public GameObject STOREBOX;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < StoreButtonArray.Length; i++)
        {
            string[] a = StoreButtonArray[i].name.Split('_');
            if (!PlayerPrefs.GetInt(a[0] + "_COUNT").Equals(0))
            {
                GameObject newButton = (GameObject)Instantiate(StoreButtonArray[i]) as GameObject;
                newButton.transform.SetParent(STOREBOX.transform.parent);
            }
        }
    }

    
}
