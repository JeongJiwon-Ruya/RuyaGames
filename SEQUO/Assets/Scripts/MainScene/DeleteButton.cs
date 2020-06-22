using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : MonoBehaviour
{
    public void OnClick_Delete()
    {
        Season_Coordinate_Controller.Instance.DeleteFlower();
    }
}
