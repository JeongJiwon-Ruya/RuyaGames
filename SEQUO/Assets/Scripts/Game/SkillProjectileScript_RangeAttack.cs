using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillProjectileScript_RangeAttack : MonoBehaviour
{
    private int splashCount;

    public int damage;
    public float speed = 1f;
    public Vector3 direction;
    public GameObject RangeSkill;
    public float stunnedTime;

    public bool MagicCircle;

    // Start is called before the first frame update

    public void SetDirection()
    {
        //방향 정규화
        direction = direction.normalized;
        //회전값을 고침
        float angle = Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
        transform.rotation = Quaternion.Euler(0, 0, (angle + 180));
    }

    private bool effectStay = false;

    public void SetSplashCount(int spc)
    {
        splashCount = spc;
    }
    public int GetSplashCount()
    {
        return splashCount;
    }

    public float elapsedTime;
    private float destroyTime = 5f;

    Vector3 effectPos;
    float fixX, fixY;
    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(direction.x * Time.deltaTime * speed, direction.y * Time.deltaTime * speed, 0f);


        elapsedTime += Time.deltaTime;
        if (elapsedTime >= destroyTime)
        {
            if (MagicCircle)
                RangeSkill.transform.localPosition = new Vector3(0f, 0f, 10f);
            else
                RangeSkill.transform.localPosition = Vector3.zero;
            RangeSkill.SetActive(false);

            gameObject.SetActive(false);
            elapsedTime = 0f;
        }

        if (effectStay)
        {
            if (MagicCircle)
                RangeSkill.transform.position = new Vector3(effectPos.x, effectPos.y, 10f);
            else
                RangeSkill.transform.localPosition = effectPos;
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
        if (collision.CompareTag("Boss"))
        {
            SoundEffectController.Instance.HitSkillSound();

            int curHel = collision.gameObject.GetComponent<BossScript>().currentHealth;
            SetSplashCount(GetSplashCount() - 1);
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
        else
        {
            SoundEffectController.Instance.HitSkillSound();

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
        }


        if (!stunnedTime.Equals(0))
            collision.SendMessage("Stun", stunnedTime);

        Vector3 d = gameObject.transform.position;

        RangeSkill.GetComponent<RangeAttack>().ON(d, MagicCircle);
        RangeSkill.SetActive(true);

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        RangeSkill.GetComponent<RangeAttack>().OFF();

        RangeSkill.SetActive(false);

        
        
        
        
        
        
        
        
        
        
        elapsedTime = 0f;
        gameObject.SetActive(false);

        yield return null;
    }
}

