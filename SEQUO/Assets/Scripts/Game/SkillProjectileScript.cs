using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillProjectileScript : MonoBehaviour
{

    public int damage;
    public float speed = 1f;
    public Vector3 direction;

    [Header("상태이상&스플래쉬효과")]
    public float stunnedTime;
    public float nuckBack;
    private int splashCount;
    public bool russel;
    public float slow;
    public float gale;
    public float slowPercentage;

    private Tree[] trees;

    [Header("Effect")]
    public GameObject effectImg;

    // Start is called before the first frame update
    void Start()
    {


    }

    public void SetDirection()
    {
        //방향 정규화
        direction = direction.normalized;
        //회전값을 고침
        float angle = Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
        transform.rotation = Quaternion.Euler(0, 0, (angle + 180));
    }

    public void SetSplashCount(int spc)
    {
        splashCount = spc;
    }
    public int GetSplashCount()
    {
        return splashCount;
    }

    public float elapsedTime = 0f;
    private float destroyTime = 0.8f;


    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(direction.x * Time.deltaTime * speed, direction.y * Time.deltaTime * speed, 0f);


        elapsedTime += Time.deltaTime;
        if (elapsedTime >= destroyTime)
        {
            gameObject.SetActive(false);
            elapsedTime = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
        {
            StartCoroutine(EffectOn(collision));

        }
    }

    IEnumerator EffectOn(Collider2D collision)
    {

        if ((collision.CompareTag("Enemy") || collision.CompareTag("Boss")) && !GetSplashCount().Equals(0))
        {
            SoundEffectController.Instance.HitSkillSound();

            if (collision.CompareTag("Boss"))
            {
                int curHel = collision.gameObject.GetComponent<BossScript>().currentHealth;
                SetSplashCount(GetSplashCount() - 1);
                if (!gale.Equals(0))
                    damage = (int)(collision.GetComponent<BossScript>().health * gale);
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

                if (!slow.Equals(0))
                {
                    collision.gameObject.GetComponent<BossScript>().Slow(slow);
                }
            }
            else
            {
                int curHel = collision.gameObject.GetComponent<EnemyMoving>().currentHealth;
                SetSplashCount(GetSplashCount() - 1);
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

                if (!slow.Equals(0))
                {
                    collision.gameObject.GetComponent<EnemyMoving>().Slow(slow, slowPercentage);
                }
            }

            if (!stunnedTime.Equals(0) && collision.gameObject.activeInHierarchy)
                collision.SendMessage("Stun", stunnedTime);

            if (!nuckBack.Equals(0))
                collision.transform.position = new Vector3(collision.transform.position.x - nuckBack, collision.transform.position.y, collision.transform.position.z);

            if (russel)
            {
                trees = GameObject.FindObjectsOfType<Tree>();
                for(int i = 0; i < trees.Length; i++)
                {
                    if (trees[i].health != trees[i].fullHealth)
                    {
                    //    int healAm = (int)(trees[i].health * 0.1f);
                        int healAm = 3;
                        trees[i].health += healAm;
                        if (trees[i].health > trees[i].fullHealth)
                            trees[i].health = trees[i].fullHealth;
                        trees[i].Heal(healAm);
                    }
                }
            }

     




            if (GetSplashCount().Equals(0))
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<Collider2D>().enabled = false;

                yield return StartCoroutine(effectImg.GetComponent<SingleAttack>().EffectOnOff(gameObject.transform.position));

                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.GetComponent<Collider2D>().enabled = true;
                gameObject.SetActive(false);
                elapsedTime = 0f;
                gameObject.transform.position = Vector3.zero;
            }
            else
            {
                yield return StartCoroutine(effectImg.GetComponent<SingleAttack>().EffectOnOff(gameObject.transform.position));

            }
            yield return null;
        }
    }
}
