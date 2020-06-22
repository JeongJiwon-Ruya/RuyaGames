using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayButtonOnUI : MonoBehaviour
{

    public GameObject rayCard;

    public void OnButtonClicked() {
    }

    public void PointDown()
    {

        if(MainController.Instance.UnitCount[gameObject.name] > 0)
        {
            GameObject rayCardClone = GameObject.Instantiate(rayCard, transform.position, Quaternion.identity) as GameObject;
        }


    }

    public void PointUp()
    {
    }
}
