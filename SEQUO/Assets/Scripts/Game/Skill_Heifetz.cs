using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Heifetz : Skill
{
    public int damage;
    private float per, perForBoss;

    private void Start()
    {
        switch (PlayerPrefs.GetInt("HEIFETZ_STAR"))
        {
            case 0:
                per = 0.8f;
                perForBoss = 0.2f;
                break;
            case 1:
                per = 0.85f;
                perForBoss = 0.22f;
                break;
            case 2:
                per = 0.90f;
                perForBoss = 0.25f;
                break;
            case 3:
                per = 0.95f;
                perForBoss = 0.3f;
                break;
            default:
                per = 0.8f;
                perForBoss = 0.02f;
                break;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(-18f, transform.position.y, transform.position.z), 0.025f);

        if (transform.position.x <= -17f)
        {
            gameObject.SetActive(false);
            GameObject.Find("HEIFETZ(Clone)").GetComponent<Hero>().BecomeMovePossible();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
        {
            if (collision.CompareTag("Enemy"))
            {
                Debug.Log("S");
                int curHel = collision.gameObject.GetComponent<EnemyMoving>().currentHealth;
                int fullHel = collision.gameObject.GetComponent<EnemyMoving>().health;
                damage = (int)(fullHel * per);
                collision.gameObject.GetComponent<EnemyMoving>().currentHealth = curHel - damage;

                collision.gameObject.GetComponent<EnemyMoving>().HPbar(damage);
                if (gameObject.activeInHierarchy)
                {
                    collision.gameObject.GetComponent<EnemyMoving>().HPDownCor();
                }
                if ((curHel - damage) <= 0)
                {
                    collision.gameObject.GetComponent<EnemyMoving>().SetActive_False();
                }
            }
            else // (collision.CompareTag("Boss"))
             {
                Debug.Log("A");
                int curHel = collision.gameObject.GetComponent<BossScript>().currentHealth;
                int fullHel = collision.gameObject.GetComponent<BossScript>().health;
                damage = (int)(fullHel * perForBoss);
                collision.gameObject.GetComponent<BossScript>().currentHealth = curHel - damage;

                collision.gameObject.GetComponent<BossScript>().HPbar(damage);
                if (gameObject.activeInHierarchy)
                {
                    collision.gameObject.GetComponent<BossScript>().HPDownCor();
                }
                if ((curHel - damage) <= 0)
                {
                    collision.gameObject.GetComponent<BossScript>().SetActive_False();
                }
            }

        }
  

    }
}
