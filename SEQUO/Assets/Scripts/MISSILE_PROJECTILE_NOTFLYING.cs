using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MISSILE_PROJECTILE_NOTFLYING : MonoBehaviour
{
    public Vector3 startPos;

    void Start()
    {
        transform.position = startPos;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(Time.deltaTime * 8f, 0f, 0f));


    }
}
