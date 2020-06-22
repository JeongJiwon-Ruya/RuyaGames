using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreasureBox : MonoBehaviour
{
    public GameObject opened;
    public GameObject closed;

    public GameObject destination;

    private Vector3 destination_position;

    float autoGet;
    float t;

    private void Start()
    {
        t = 0;
        autoGet = 4f;
    }
    private void Update()
    {
        
        t += Time.deltaTime;
        if (t >= autoGet)
        {
            t = 0f;
            OnMouseDown();
        }
        
        
    }

    public void Go(GameObject parent)
    {
        gameObject.transform.parent = parent.transform;
        gameObject.transform.localPosition = new Vector3(0, -3f, -8f);

        destination = GameObject.Find("Destination");
    }

    bool touched = false;

    private void OnMouseDown()
    {
        if (!touched)
        {
            touched = true;
            SoundEffectController.Instance.BoxOpenSound();

            opened.gameObject.SetActive(false);
            closed.gameObject.SetActive(true);

            destination_position = new Vector3(destination.transform.position.x - 0.2f, destination.transform.position.y + 0.5f, destination.transform.position.z);

            StartCoroutine(MoveBox());
        }

    }

    IEnumerator MoveBox()
    {
        var FRAME = new WaitForSeconds(Time.deltaTime);

        yield return FRAME;

        while (Mathf.Abs(gameObject.transform.position.x - destination_position.x) >= 0.1f )
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, destination_position, 0.1f);
            yield return FRAME;
        }
        MainController.Instance.treasureboxCount++;
        GameObject.Find("TreasureCountOutLine").GetComponentInChildren<TextMeshPro>().text = (int.Parse(GameObject.Find("TreasureCountOutLine").GetComponentInChildren<TextMeshPro>().text) + 1).ToString();
        Destroy(gameObject);
   }
}
