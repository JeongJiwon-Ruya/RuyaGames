using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingScript : MonoBehaviour
{
    public GameObject rey;


    // Update is called once per frame
    void Update()
    {

        
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 16));

        if (Input.GetMouseButtonDown(0))
        {

            GameObject new1 = GameObject.Instantiate(rey,transform) as GameObject;

            /*
            GameObject projectile = GameObject.Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<ProjectileScript>().direction = direction;
            */

            Destroy(gameObject);
        }
    }
}
