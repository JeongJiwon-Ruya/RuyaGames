using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aria_ArrowGenerator : MonoBehaviour
{
    public GameObject Aria_Arrow;
    private List<GameObject> Arrows = null;
    private float per, perForBoss;

    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerPrefs.GetInt("ARIA_STAR"))
        {
            case 0:
                per = 0.1f;
                perForBoss = 0.02f;
                break;
            case 1:
                per = 0.12f;
                perForBoss = 0.03f;
                break;
            case 2:
                per = 0.14f;
                perForBoss = 0.04f;
                break;
            case 3:
                per = 0.16f;
                perForBoss = 0.05f;
                break;
            default:
                per = 0.1f;
                perForBoss = 0.02f;
                break;
        }

        Arrows = new List<GameObject>();
        transform.position = new Vector3(-5.3f, 7f, 0f);

        for(int i = 0; i < 100; i++)
        {
            GameObject Arrow = (GameObject)Instantiate(Aria_Arrow);
            Arrow.GetComponent<Aria_Arrow>().setPercent(per, perForBoss);
            Arrow.transform.SetParent(gameObject.transform);
            Arrow.SetActive(false);
            Arrows.Add(Arrow);
        }
    }

    public void SkillActive()
    {
        StartCoroutine(ArrowRain());
    }

    IEnumerator ArrowRain()
    {
        var wait = new WaitForSeconds(0.06f);
        for (int i = 0; i < 100; i++)
        {
            int randomX = Random.Range(-7, 7);
            Arrows[i].transform.position = new Vector3(randomX, 6.45f, -9f);
            Arrows[i].SetActive(true);
            yield return wait;
        }
    }

}
