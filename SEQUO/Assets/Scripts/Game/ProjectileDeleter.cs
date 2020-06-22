using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDeleter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SkillProjectile") || collision.CompareTag("Projectile"))
        {
            collision.gameObject.transform.position = Vector3.zero;
            collision.gameObject.SetActive(false);

        }
    }
}
