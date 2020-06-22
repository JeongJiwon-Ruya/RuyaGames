using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardMoving : MonoBehaviour
{
    Vector3 Destination;

    // Update is called once per frame


    public void OutParent()
    {
        gameObject.transform.parent = GameObject.Find("Destination").transform;
        Destination = new Vector3(-20f, 10f, 0f);

        StartCoroutine(MoveAnim());
    }

    IEnumerator MoveAnim()
    {
        var FRAME = new WaitForSeconds(Time.deltaTime);

        yield return FRAME;

        while (Mathf.Abs(gameObject.transform.localPosition.x - Destination.x) >= 20f)
        {
            gameObject.transform.localPosition = Vector3.Lerp(gameObject.transform.localPosition, Destination, 0.1f);
            yield return FRAME;
        }
        Destroy(gameObject);
    }
}
