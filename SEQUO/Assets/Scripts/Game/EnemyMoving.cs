using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyMoving : MonoBehaviour
{
    protected bool keepgoing = true;
    protected bool koonekoone = false;
    protected bool touchingTree = false;


    private Animator anim;
    private Rigidbody2D rb2d;
    private SpriteRenderer spr;

    public float speed = 1.0f;
    public int health;
    public int currentHealth;
    private int damaged;
    public TextMeshPro textMesh;

    public GameObject hpBar;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        currentHealth = health;
        
    }

    void Update()
    {
        if(keepgoing)
            transform.Translate(new Vector3(speed * Time.deltaTime, 0.0f, 0.0f));
        if(koonekoone)
            transform.Translate(new Vector3(-(speed * 0.001f * Time.deltaTime), 0.0f, 0.0f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("tree"))
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
            touchingTree =false;
            keepgoing = true;
            koonekoone = false;
        }
    }


    public void Stun(float sec)
    {
        keepgoing = true;
        koonekoone = false;
     //   StopCoroutine("Stunned");
        StartCoroutine("Stunned",sec);
    }
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

    private int iceStack = 0;
    public void Slow(float sec, float percentage)
    {
        if (iceStack > 3)
            return;
        else
        {
            if(gameObject.activeInHierarchy)
                StartCoroutine(SlowD(sec, percentage));
        }
    }
    IEnumerator SlowD(float sec, float percentage)
    {
    
        speed *= percentage;
        iceStack++;
        yield return new WaitForSeconds(sec);
        iceStack--;
        speed *= (1 / percentage);
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
        keepgoing = true;
        koonekoone = false;
        gameObject.SetActive(false);
    }

    public void HPDownCor()
    {
        if(gameObject.activeInHierarchy)
            StartCoroutine("HPDown");
    }

    private IEnumerator HPDown()
    {

        spr.color = new Color(255f, 0f, 0f);
        yield return new WaitForSeconds(0.1f);
        spr.color = new Color(255f, 255f, 255f);


    }
}
