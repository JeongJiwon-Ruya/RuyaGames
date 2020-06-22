using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    public int health;
    public int fullHealth;
    private SpriteRenderer spr;
    public GameObject hpBar;
    private int damage;
    public GameObject healingCross;
    private Vector3 currentPos;

    GameObject EGM;

    private void Start()
    {
        EGM = GameObject.Find("EnemyGeneratingMachine");

        spr = GetComponent<SpriteRenderer>();
        health = 100;
        fullHealth = health;

        if (PlayerPrefs.GetString("PLAYMODE").Equals("ADVENTURE"))
        {
            switch (PlayerPrefs.GetString("DIFFICULTY", "EASY"))
            {
                case "EASY":
                    damage = 5;
                    break;
                case "NORMAL":
                    damage = 7;
                    break;
                case "HARD":
                    damage = 8;
                    break;
                case "INSANE":
                    damage = 9;
                    break;
                case "HELL":
                    damage = 13;
                    break;
            }
        }
        else
        {
            int currentRound = EGM.GetComponent<EnemyGeneratingMachine_Game>().currentRound;

            if (0 < currentRound && currentRound <= 5)
                damage = 5;
            else if (0 < currentRound && currentRound <= 5)
                damage = 7;
            else if (5 < currentRound && currentRound <= 10)
                damage = 9;
            else if (10 < currentRound && currentRound <= 15)
                damage = 11;
            else if (15 < currentRound && currentRound <= 20)
                damage = 13;
            else if (20 < currentRound && currentRound <= 25)
                damage = 15;
            else if (25 < currentRound && currentRound <= 30)
                damage = 17;
            else if (30 < currentRound && currentRound <= 35)
                damage = 20;
            else if (35 < currentRound && currentRound <= 40)
                damage = 23;
            else if (40 < currentRound && currentRound <= 45)
                damage = 24;
            else if (45 < currentRound && currentRound <= 50)
                damage = 25;
            else if (50 < currentRound && currentRound <= 55)
                damage = 26;
            else if (55 < currentRound && currentRound <= 60)
                damage = 27;
            else
                damage = 28;
            }


        currentPos = healingCross.transform.position;


    }


    private bool coroutinePlaying = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            StartCoroutine("Hit");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile"))
        {
            StartCoroutine("Hit");
            Destroy(collision.gameObject);
        }
    }

    public IEnumerator Hit()
    {
        if (!coroutinePlaying)
        {
            coroutinePlaying = true;

            health -= damage;
            if (health <= 0)
            {
                GameOver();
                Destroy(gameObject);

            }

            spr.color = new Color(255f, 0f, 0f);

            float x_pos = hpBar.transform.position.x;
            float x_sca = hpBar.transform.localScale.x;

            x_pos -= (0.6646f / fullHealth) * damage;
            x_sca -= (2.011f / fullHealth) * damage;

            hpBar.transform.position = new Vector3(x_pos, hpBar.transform.position.y, hpBar.transform.position.z);
            hpBar.transform.localScale = new Vector3(x_sca, 1f, 1f);

            yield return new WaitForSeconds(0.2f);
            spr.color = new Color(255f, 255f, 255f);
            yield return new WaitForSeconds(1f);

       
            coroutinePlaying = false;
        }

        else
            yield return null;
    }

    private void GameOver()
    {
        SoundEffectController.Instance.GameOverSound();
        if(PlayerPrefs.GetString("PLAYMODE").Equals("ADVENTURE"))
            MainController.Instance.GameOver();
        if (PlayerPrefs.GetString("PLAYMODE").Equals("INFINITY"))
            MainController.Instance.GameOver_INFINITY();
    }

    IEnumerator HealingAnim()
    {
        StopCoroutine(HealingAnim());
        healingCross.transform.position = currentPos;

        healingCross.SetActive(true);
        var wait = new WaitForSeconds(Time.deltaTime);
        float elapsedT = 0f;
        while (elapsedT < 0.3f)
        {
            healingCross.transform.position = new Vector3(healingCross.transform.position.x, healingCross.transform.position.y + 0.01f, healingCross.transform.position.z);
            elapsedT += Time.deltaTime;
            yield return wait;
        }
        yield return null;
        healingCross.SetActive(false);
    }

    public void Heal(int healed)
    {

        StartCoroutine("HealingAnim");

        float x_pos = hpBar.transform.position.x;
        float x_sca = hpBar.transform.localScale.x;

        if ((health + healed) > fullHealth)
        {
            x_pos = 1.1226f;
            x_sca = 2.011f;
        }
        else
        {
            x_pos += (0.6646f / fullHealth) * healed;
            x_sca += (2.011f / fullHealth) * healed;
        }

        hpBar.transform.position = new Vector3(x_pos, hpBar.transform.position.y, hpBar.transform.position.z);
        hpBar.transform.localScale = new Vector3(x_sca, 1f, 1f);
    }


}
