using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MotherUnitScript : MonoBehaviour
{

    public float reloadTime; // 리로드타임
    public int splashCount;
    public int skillSplashCount;



    [Header("발사체&스킬")]
    public GameObject projectilePrefab; //발사체 타입
    public GameObject skillPrefab;
    public GameObject skillPrefab2;
    public int skillPercentage; // 20 : 20%,   54 : 54%
    public int skillPercentage2;
    public bool projectileSpin;

    private float elapsedTime; // 발사 직후로부터 흐른 시간

    private bool choong = false;
    private bool dragged = false;
    private Transform enemydir;

    private GameObject mixBox1;
    private GameObject mixBox2;
    private GameObject mixBox3;

    private float x;
    private float y;

    float AriaConstant = 0f;

    Animator animator;

    private List<GameObject> projectile = null;

    private void Start()
    {
        if (PlayerPrefs.GetString("HERO_SELECTED", "HEIFETZ").Equals("ARIA"))
        {
            switch (PlayerPrefs.GetInt("ARIA_STAR", 0))
            {
                case 0:
                    AriaConstant = 0.1f;
                    break;
                case 1:
                    AriaConstant = 0.12f;
                    break;
                case 2:
                    AriaConstant = 0.14f;
                    break;
                case 3:
                    AriaConstant = 0.16f;
                    break;
            }
        }


        reloadTime -= (reloadTime * AriaConstant);

        animator = GetComponent<Animator>();

        float j = 0;
        float l = 0;

        projectile = new List<GameObject>();
        if(skillPercentage != 0)
        {
            j = skillPercentage * 0.2f;

            for (int k = 0; k < j; k++)
            {
                GameObject obj = (GameObject)Instantiate(skillPrefab);
                obj.SetActive(false);
                projectile.Add(obj);
            }

        }


        if(skillPercentage2 != 0)
        {
            l = skillPercentage2 * 0.2f;
            for (int m = 0; m < l; m++)
            {
                GameObject obj = (GameObject)Instantiate(skillPrefab2);
                obj.SetActive(false);
                projectile.Add(obj);
            }
        }

        for (int i  = 0; i< (20-(j+l)); i++)
        {
            GameObject obj = (GameObject)Instantiate(projectilePrefab);
            obj.SetActive(false);
            projectile.Add(obj);
        }

        mixBox1 = GameObject.Find("MixBox1");
        mixBox2 = GameObject.Find("MixBox2");
        mixBox3 = GameObject.Find("MixBox3");
    }


    private void OnMouseDown()
    {
        float xStair;
        switch (gameObject.tag)
        {
            case "3grade":
                xStair = 0.3f;
                break;
            case "4grade":
                xStair = 0.5f;
                break;
            case "5grade":
                xStair = 0.75f;
                break;
            default:
                xStair = 0;
                break;
        }

        CoordinateSystem.Instance.ExitProcess(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - xStair), projectilePrefab.name);
        dragged = true;
    }

    private void OnMouseDrag()
    {
        {
            x = Input.mousePosition.x;
            y = Input.mousePosition.y;

            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 16));

        }


    }
    private void OnMouseUp()
    {
        {
            MainController.Instance.UnitCount[projectilePrefab.name]++;
            MainController.Instance.PaletteCountRefresh(projectilePrefab.name);

            float fixedX = 0f;
            float fixedY = 0f;
            float stairZ = 0;
            bool xInRange = true;
            bool yInRange = true;
            bool xForMix = false;
            bool yForMix = false;

            if (1331 <= x && x < 1476)
                fixedX = 2.4f;
            else if (1476 <= x && x < 1633)
                fixedX = 3.9f;
            else if (1633 <= x && x < 1784)
                fixedX = 5.4f;
            else if (1849 <= x && x < 1946)
            {
                fixedX = 7.572f;
                xForMix = true;
                xInRange = false;
            }
            else if (1983 <= x && x < 2088)
            {
                fixedX = 8.949f;
                xForMix = true;
                xInRange = false;
            }
            else if (2128 <= x && x < 2222)
            {
                fixedX = 10.331f;
                xForMix = true;
                xInRange = false;
            }
            else
                xInRange = false;

            if (0 <= y && y < 149)
            {
                fixedY = -4.5f;
                stairZ = 0.01f;
            }
            else if (149 <= y && y < 300 && !xForMix)
            {
                fixedY = -3f;
                stairZ = 0.02f;
            }
            else if ((300 <= y && y < 450))
            {
                fixedY = -1.5f;
                stairZ = 0.03f;
            }
            else if (450 <= y && y < 600)
            {
                fixedY = 0f;
                stairZ = 0.04f;
            }
            else if (600 <= y && y <= 750)
            {
                fixedY = 1.5f;
                stairZ = 0.05f;
            }
            else if ((173.8569f <= y && y < 276.1851f) && xForMix)
            {
                fixedY = -1.356f;
                yForMix = true;
                yInRange = false;
            }
            else
                yInRange = false;
   

            if(xInRange && yInRange)
            {
                if (CoordinateSystem.Instance.EnterProcess(new Vector2(fixedX, fixedY), projectilePrefab.name))
                {
                    float xStair;
                    switch (gameObject.tag)
                    {
                        case "3grade":
                            xStair = 0.3f;
                            break;
                        case "4grade":
                            xStair = 0.5f;
                            break;
                        case "5grade":
                            xStair = 0.75f;
                            break;
                        default:
                            xStair = 0;
                            break;
                    }
                    gameObject.transform.position = new Vector3(fixedX, fixedY + xStair, stairZ);
                }
                else
                {
                    CoordinateSystem.Instance.ExitProcess(new Vector2(fixedX, fixedY), projectilePrefab.name);
                    Destroy(gameObject);

                }

            }

            if (!xInRange)
            {
                if (!yForMix)
                {
                    Destroy(gameObject);
                    return;
                }
            }

            if (!yInRange)
            {
                if (!xForMix)
                {
                    Destroy(gameObject);
                    return;
                }
            }

            if (xForMix && yForMix)
            {
                if (fixedX == 7.572f)
                {
                    if (mixBox1.GetComponent<SpriteRenderer>().sprite == null)
                    {
                        mixBox1.GetComponent<SpriteRenderer>().sprite = Resources.Load(projectilePrefab.name, typeof(Sprite)) as Sprite;
                        MainController.Instance.UnitCount[mixBox1.GetComponent<SpriteRenderer>().sprite.name]--;
                        MainController.Instance.PaletteCountRefresh(mixBox1.GetComponent<SpriteRenderer>().sprite.name);
                    }


                }
                else if (fixedX == 8.949f)
                {
                    if (mixBox2.GetComponent<SpriteRenderer>().sprite == null)
                    {
                        mixBox2.GetComponent<SpriteRenderer>().sprite = Resources.Load(projectilePrefab.name, typeof(Sprite)) as Sprite;
                        MainController.Instance.UnitCount[mixBox2.GetComponent<SpriteRenderer>().sprite.name]--;

                        MainController.Instance.PaletteCountRefresh(mixBox2.GetComponent<SpriteRenderer>().sprite.name);
                    }
                }
                else if (fixedX == 10.331f)
                {
                    if (mixBox3.GetComponent<SpriteRenderer>().sprite == null)
                    {
                        mixBox3.GetComponent<SpriteRenderer>().sprite = Resources.Load(projectilePrefab.name, typeof(Sprite)) as Sprite;
                        MainController.Instance.UnitCount[mixBox3.GetComponent<SpriteRenderer>().sprite.name]--;

                        MainController.Instance.PaletteCountRefresh(mixBox3.GetComponent<SpriteRenderer>().sprite.name);
                    }
                }

                Destroy(gameObject);
                return;
            }
            

        }
        dragged = false;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
    

        if (elapsedTime >= reloadTime)
        {
            //흐른 시간을 리셋한다.
            elapsedTime = 0;

            //하나라도 감지됬을때
            if (choong && !dragged)
            {
                animator.SetBool("InRanged", true);
                //타깃으로의 방향을 얻는다
                Transform target = enemydir;
                
                //나중에 target이 존재하는지 코디이잉
                

                int listSearch = Random.Range(0, 20);
                GameObject activeProjectile = projectile[listSearch];
                while (activeProjectile.activeInHierarchy.Equals(true))
                {
                    listSearch = Random.Range(0, 20);
                    activeProjectile = projectile[listSearch];
                }
                if ((activeProjectile.activeInHierarchy).Equals(false))
                {
                    /*유닛 등급에 따라 방향 수정*/
                    Vector3 StairPos;
                    switch (gameObject.tag)
                    {
                        case "3grade":
                            StairPos = new Vector2(gameObject.transform.position.x , gameObject.transform.position.y);
                            break;
                        case "4grade":
                            StairPos = new Vector2(gameObject.transform.position.x , gameObject.transform.position.y);
                            break;
                        case "5grade":
                            StairPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y-0.15f);
                            break;
                        default:
                            StairPos = gameObject.transform.position;
                            break;
                    }
                    Vector2 direction = (target.position - StairPos).normalized;

                    activeProjectile.transform.position = new Vector3(transform.position.x - 0.4f, StairPos.y, -9f);
                    activeProjectile.transform.rotation = Quaternion.identity;
                    if (activeProjectile.CompareTag("Projectile"))
                    {
                        activeProjectile.GetComponent<ProjectileScript>().elapsedTime = 0f;
                        activeProjectile.GetComponent<ProjectileScript>().SetSplashCount(splashCount);
                        activeProjectile.GetComponent<ProjectileScript>().direction = direction;
                        activeProjectile.GetComponent<ProjectileScript>().SetDirection();
                        if (MainController.Instance.Merced())
                            activeProjectile.GetComponent<ProjectileScript>().IsMercy();


                        activeProjectile.GetComponent<ProjectileScript>().SetProjectileSpin(projectileSpin);
                    }
                    else if (activeProjectile.CompareTag("SkillProjectile"))
                    {
                        activeProjectile.GetComponent<SkillProjectileScript>().elapsedTime = 0f;

                        activeProjectile.GetComponent<SkillProjectileScript>().SetSplashCount(skillSplashCount);
                        activeProjectile.GetComponent<SkillProjectileScript>().direction = direction;
                        activeProjectile.GetComponent<SkillProjectileScript>().SetDirection();


                    }
                    else if (activeProjectile.CompareTag("SkillProjectile_Range"))
                    {
                        activeProjectile.GetComponent<SkillProjectileScript_RangeAttack>().elapsedTime = 0f;

                        activeProjectile.GetComponent<SkillProjectileScript_RangeAttack>().SetSplashCount(splashCount);
                        activeProjectile.GetComponent<SkillProjectileScript_RangeAttack>().direction = direction;
                        activeProjectile.GetComponent<SkillProjectileScript_RangeAttack>().RangeSkill.SetActive(false);
                        activeProjectile.GetComponent<SkillProjectileScript_RangeAttack>().SetDirection();


                    }
                    activeProjectile.GetComponent<SpriteRenderer>().enabled = true;
                    activeProjectile.GetComponent<Collider2D>().enabled = true;

                    activeProjectile.SetActive(true);
                }
                
            }
            else
            {

                animator.SetBool("InRanged", false);
            }
        }

            elapsedTime += Time.deltaTime;
            choong = false;

    
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss")){
            choong = true;
            enemydir = other.transform;
        }

    }

}
