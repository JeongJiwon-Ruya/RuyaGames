using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoordinateButton : MonoBehaviour
{
    Button btn;
    GameController GC;
    int ownX, ownZ;


    private void Start()
    {
        string[] a = name.Split(',');
        ownX = int.Parse(a[0]);
        ownZ = int.Parse(a[1]);

        GC = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void OnMouseDown()
    {
        GC.ReceiveCoordinate(ownX, ownZ);
    }
}

