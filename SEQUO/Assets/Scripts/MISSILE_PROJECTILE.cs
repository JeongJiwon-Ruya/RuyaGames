using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MISSILE_PROJECTILE : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 direction;
    public bool projectileSpin;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos;
    }

    int z = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(direction.x * Time.deltaTime * 1.5f, direction.y * Time.deltaTime * 1.5f, 0f);
        
        if (projectileSpin)
        {
            z += 30;
            transform.rotation = Quaternion.Euler(0, 0, z);
        }
    }
}
