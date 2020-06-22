using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMoving : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-0.03f, 0f, 0f));
        if (transform.position.x < -48f)
            transform.position = new Vector3(48f, 0f, 2f);
    }
}
