using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixBox : MonoBehaviour
{
    private SpriteRenderer spr;
    private string unit;
        

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(spr.sprite != null)
        {
            unit = spr.sprite.name;
        }

        

    }
}
