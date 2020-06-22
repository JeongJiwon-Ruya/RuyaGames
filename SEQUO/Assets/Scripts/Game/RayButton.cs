using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayButton : MonoBehaviour
{
    public GameObject rayCard;

    private void OnMouseDown()
    {/*
        spr.sprite = sprite[0];
        gameObject.transform.localScale = new Vector3(0.15f, 0.15f);
    */
        
        GameObject rayCardClone = GameObject.Instantiate(rayCard, transform.position, Quaternion.identity) as GameObject;
    }
    /*
    //콜라이더 만들어야됨, 매프레임 호출
    private void OnMouseDrag()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 16));

    }

    private void OnMouseUp()
    {
        GameObject new1 = GameObject.Instantiate(rayPrefab, transform.position, Quaternion.identity) as GameObject;

        this.gameObject.SetActive(false);
    }
    */

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
