using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aria_Arrow : MonoBehaviour
{
    private int damage;
    private float percent, percentForBoss;

    public void setPercent(float per, float perForBoss)
    {
        percent = per;
        percentForBoss = perForBoss;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-0.001f, -0.359f, 0f));

        if(transform.position.y < -10f)
        {
            gameObject.SetActive(false);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            int curHel = collision.gameObject.GetComponent<EnemyMoving>().currentHealth;
            int fullHel = collision.gameObject.GetComponent<EnemyMoving>().health;
            damage = (int)(curHel * percent);
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
        if (collision.CompareTag("Boss"))
        {
            int curHel = collision.gameObject.GetComponent<BossScript>().currentHealth;
            int fullHel = collision.gameObject.GetComponent<BossScript>().health;
            damage = (int)(curHel * percentForBoss);
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
