using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RangeAttack : MonoBehaviour
{
    public int skillDamage;
    public int stunTime;
    public bool nuckBack;
    public int slow;
    public float slowPercentage;
    public bool meryEl;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!stunTime.Equals(0))
            {
                collision.SendMessage("Stun", stunTime);
            }
            if (nuckBack)
            {
                collision.transform.position = new Vector3(collision.transform.position.x - 0.3f, collision.transform.position.y, collision.transform.position.z);
            }
            if (!slow.Equals(0))
            {
                collision.gameObject.GetComponent<EnemyMoving>().Slow(slow,slowPercentage);
            }

            if (meryEl)
            {
                collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, -1.5f, collision.gameObject.transform.position.z);
            }

            collision.gameObject.GetComponent<EnemyMoving>().currentHealth -= skillDamage;
            collision.gameObject.GetComponent<EnemyMoving>().HPbar(skillDamage);
            if (gameObject.activeInHierarchy)
            {
                collision.gameObject.GetComponent<EnemyMoving>().HPDownCor();
            }
            if (collision.gameObject.GetComponent<EnemyMoving>().currentHealth <= 0)
            {
                collision.gameObject.GetComponent<EnemyMoving>().SetActive_False();
            }
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            if (!stunTime.Equals(0))
            {
                collision.SendMessage("Stun", stunTime);
            }
            if (nuckBack)
            {
                collision.transform.position = new Vector3(collision.transform.position.x - 0.3f, collision.transform.position.y, collision.transform.position.z);
            }
            if (!slow.Equals(0))
            {
                collision.gameObject.GetComponent<BossScript>().Slow(slow);
            }

            if (meryEl)
            {
                collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, -1.5f, collision.gameObject.transform.position.z);
            }

            collision.gameObject.GetComponent<BossScript>().currentHealth -= skillDamage;
            collision.gameObject.GetComponent<BossScript>().HPbar(skillDamage);
            if (gameObject.activeInHierarchy)
            {
                collision.gameObject.GetComponent<BossScript>().HPDownCor();
            }
            if (collision.gameObject.GetComponent<BossScript>().currentHealth <= 0)
            {
                collision.gameObject.GetComponent<BossScript>().SetActive_False();
            }
        }
    }

    private Vector3 MotherPos;
    private bool MaCc;

    private void FixedUpdate()
    {
        if (gameObject.activeSelf)
        {
            if (MaCc)
                transform.position = new Vector3(MotherPos.x - 0.8f, MotherPos.y, 11f);
            else
                transform.position = new Vector3(MotherPos.x - 0.8f, MotherPos.y, MotherPos.z);
            GetComponent<SpriteRenderer>().enabled = true;
        }    
    }

    public void ON(Vector3 vec, bool MC)
    {
        MotherPos = vec;
        MaCc = MC;
        /*
        Vector3 MotherPosY = vec;
        MotherPos = new Vector3(MotherPosY.x - 1f, MotherPosY.y, MotherPosY.z);
        */
    }

    public void OFF()
    {
        MotherPos = Vector3.zero;
        GetComponent<SpriteRenderer>().enabled = false;
    }

}
