using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    private int splashCount;
    private bool projectileSpin;

    public int damage;
    public int damageLow;
    public int damageUpper;
    public float speed = 1f;
    public Vector3 direction;

    private bool isMercy = false;
    private float HeifetzConstant;

    private void Start()
    {
        HeifetzConstant = 1f;

        if (PlayerPrefs.GetString("HERO_SELECTED", "HEIFETZ").Equals("HEIFETZ"))
        {
            switch (PlayerPrefs.GetInt("HEIFETZ_STAR", 0))
            {
                case 0:
                    HeifetzConstant = 1.05f;
                    break;
                case 1:
                    HeifetzConstant = 1.08f;
                    break;
                case 2:
                    HeifetzConstant = 1.12f;
                    break;
                case 3:
                    HeifetzConstant = 1.15f;
                    break;
            }
        }
    }

    public void SetDirection()
    {
        //방향 정규화
        direction = direction.normalized;
        //회전값을 고침
        float angle = Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
        transform.rotation = Quaternion.Euler(0, 0, (angle + 180));
    }

    public void IsMercy()
    {
        isMercy = true;
    }

    public void SetSplashCount(int spc)
    {
        splashCount = spc;
    }
    public int GetSplashCount()
    {
        return splashCount;
    }
    public void SetProjectileSpin(bool spin)
    {
        projectileSpin = spin;
    }

    float z = 1;
    // Update is called once per frame
    void FixedUpdate()
    {
    
        transform.position = transform.position + new Vector3(direction.x * Time.deltaTime * speed, direction.y * Time.deltaTime * speed, 0f);

        if (projectileSpin)
        {
            z += 30;
            transform.rotation = Quaternion.Euler(0, 0, z);
        }


        elapsedTime += Time.deltaTime;
        if(elapsedTime >= destroyTime)
        {
            
            gameObject.SetActive(false);
            elapsedTime = 0f;
        }
        
    }

    public float elapsedTime = 0f;
    private float destroyTime = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Enemy") || collision.CompareTag("Boss")) && !GetSplashCount().Equals(0))
        {

            PunchSound.Instance.HitSound();

            damage = (int)(Random.Range(damageLow, damageUpper) * HeifetzConstant);
            if (isMercy)
                damage += (int)(damage * 0.4f);

            if (collision.CompareTag("Boss"))
            {
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
            if (GetSplashCount().Equals(0))
            {
                elapsedTime = 0f;
                gameObject.transform.position = Vector3.zero;
                gameObject.SetActive(false);
            }
        }
   
        
    }
}
