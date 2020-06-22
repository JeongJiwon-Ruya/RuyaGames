using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossScript : MonoBehaviour
{
    protected bool keepgoing = true;
    protected bool koonekoone = false;
    protected bool touchingTree = false;


    private Animator anim;
    private Rigidbody2D rb2d;
    private SpriteRenderer spr;

    public float speed = 0.5f;
    public int health;
    public int currentHealth;
    private int damaged;
    public TextMeshPro textMesh;

    public GameObject hpBar;
    public GameObject hpBarOutline;

    public GameObject treasureBoxPrefab;

    public Sprite die1, die2, die3;

    private GameObject treasureBox;

    private bool LastBoss;

    GameObject treeSet;
    Tree[] trees;
    public GameObject missilePrefab;
    public GameObject missilePrefab_flying;
    public bool isFlying;
     float coolTime = 4.0f;
    float currentTime = 0f;

    private void Start()
    {
        if (PlayerPrefs.GetString("PLAYMODE").Equals("ADVENTURE"))
        {
            switch (PlayerPrefs.GetString("DIFFICULTY"))
            {
                case "EASY":
                    coolTime = 5.0f;
                    break;
                case "NORMAL":
                    coolTime = 4.0f;
                    break;
                case "HARD":
                    coolTime = 3.5f;
                    break;
                case "INSANE":
                    coolTime = 3.0f;
                    break;
            }
        }


        treeSet = GameObject.Find("Trees");
        trees = treeSet.GetComponentsInChildren<Tree>();

        treasureBox = GameObject.Instantiate(treasureBoxPrefab) as GameObject;

        treasureBox.GetComponent<TreasureBox>().Go(gameObject);

        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        currentHealth = health;

        textMesh.text = currentHealth.ToString();

    }

    void Update()
    {
        
        if (keepgoing)
        {
            currentTime += Time.deltaTime;
            if (currentTime > coolTime)
            {
                if (isFlying)
                {
                    float y = Random.Range(-5, 3);
                    GameObject missile = (GameObject)Instantiate(missilePrefab);
                    missile.transform.SetParent(treeSet.transform);
                    missile.GetComponent<MISSILE_PROJECTILE>().startPos = new Vector3(transform.position.x + 0.3f, transform.position.y + 1f, transform.position.z);
                    missile.GetComponent<MISSILE_PROJECTILE>().direction = new Vector3(1.125f - transform.position.x, y);
                    missile.transform.rotation = new Quaternion(1.125f - transform.position.x, y - transform.position.y, 0f, 0f);
                }
                else
                {
                    float y = Random.Range(-4.5f, 1.5f);
                    GameObject missile = (GameObject)Instantiate(missilePrefab_flying);
                    missile.transform.SetParent(treeSet.transform);
                    missile.GetComponent<MISSILE_PROJECTILE_NOTFLYING>().startPos = new Vector3(transform.position.x + 1f, y, transform.position.z);
                }

                currentTime = 0f;
            }

            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (koonekoone)
            transform.Translate(new Vector3(-(speed * 0.001f * Time.deltaTime), 0, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tree"))
        {
            touchingTree = true;
            keepgoing = false;
            koonekoone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("tree"))
        {
            touchingTree = false;
            keepgoing = true;
            koonekoone = false;
        }
    }

    public void IsLastBoss()
    {
        LastBoss = true;
    }

    public void Stun(float sec)
    {/*
        StopCoroutine("Stunned");
        StartCoroutine("Stunned", sec);*/
    }
    /*
    IEnumerator Stunned(float sec)
    {

        anim.SetBool("Stunned", true);
        koonekoone = true;
        keepgoing = false;
        yield return new WaitForSeconds(sec);
        if (touchingTree)
        {
            keepgoing = false;
            koonekoone = true;
        }
        else
        {
            keepgoing = true;
            koonekoone = false;

        }
        anim.SetBool("Stunned", false);
    }
    */

    public void Slow(float sec)
    {
        StartCoroutine(SlowD(sec));
    }
    IEnumerator SlowD(float sec)
    {
        speed = speed * 0.5f;
        yield return new WaitForSeconds(sec);
        speed = speed * 2f;
    }

    public void HPbar(int damage)
    {
        float x_pos = hpBar.transform.localPosition.x;
        float x_sca = hpBar.transform.localScale.x;

        x_pos -= (0.44f / health) * damage;
        x_sca -= (1.38f / health) * damage;

        hpBar.transform.localPosition = new Vector3(x_pos, hpBar.transform.localPosition.y, hpBar.transform.localPosition.z);
        hpBar.transform.localScale = new Vector3(x_sca, hpBar.transform.localScale.y, hpBar.transform.localScale.z);

        textMesh.text = currentHealth.ToString();


    }

    public void SetActive_False()
    {
        keepgoing = false;
        koonekoone = true;
        hpBarOutline.SetActive(false);
        gameObject.GetComponent<Collider2D>().enabled = false;
        anim.enabled = false;
        StartCoroutine(DieAnimation());
        if (LastBoss)
        {
            if(PlayerPrefs.GetString("PLAYMODE").Equals("ADVENTURE"))
                MainController.Instance.GameClear();
        }
    }

    IEnumerator DieAnimation()
    {
        var wait = new WaitForSeconds(0.3f);
        gameObject.GetComponent<SpriteRenderer>().sprite = die1;
        yield return wait;
        gameObject.GetComponent<SpriteRenderer>().sprite = die2;
        yield return wait;
        gameObject.GetComponent<SpriteRenderer>().sprite = die3;


        treasureBox.gameObject.GetComponent<TreasureBox>().transform.parent = GameObject.Find("MainController").transform;
        treasureBox.gameObject.SetActive(true);

        yield return wait;
        gameObject.SetActive(false);
    }

    public void HPDownCor()
    {
        if (gameObject.activeInHierarchy)
            StartCoroutine("HPDown");
    }

    private IEnumerator HPDown()
    {

        spr.color = new Color(255f, 0f, 0f);
        yield return new WaitForSeconds(0.1f);
        spr.color = new Color(255f, 255f, 255f);


    }
}
