using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGeneratingMachine_Game : MonoBehaviour
{
    //제너럴컨트롤러에게서 스테이지 정보, 난이도(처음에만)정보 입력받은걸 기반으로 몬스터 생성.
    //체력 관리해서 생성
    //난이도 따라 몬스터 속도 조절

        /* 
         * 시간의 흐름을 입력받으며 한라운드동안 몬스터 생성.
         * 아마 제너럴에서 선언해서 사용할듯.
         * 코루틴 사용.
         * 생성 좌표는 -4.5 -3 -1.5 0 1.5
         * 
         */
    public GameObject[] EnemyArrays;
    public GameObject[] BossArrays;

    public GameObject Content;

    [Header("라운드표기")]
    public GameObject Round_X;
    public Sprite[] roundSprite;


    [Header("라운드 분기마다 달라지는 값들")]
    private float enemySpeed = 0f;
    private int maxRound;

    private int monsterPerRound;
    private int monsterPerRound_Q2;
    private int monsterPerRound_Q3;
    private int monsterPerRound_Q4;
    private int monsterPerRound_Q5;

    private float roundTime;
    public int currentRound = 1;

    private float monsterReloadTime;
    private float monsterReloadTime_Q2;
    private float monsterReloadTime_Q3;
    private float monsterReloadTime_Q4;
    private float monsterReloadTime_Q5;


    private int enemyHealth = 0;
    private int enemyHealth_Q2;
    private int enemyHealth_Q3;
    private int enemyHealth_Q4;
    private int enemyHealth_Q5;

    public GameObject spawnedMonstersBox;
    public GameObject GameClearPopup;

    public Text round;
    public Text endRound;
    public Slider gage;


    private List<GameObject> monsters = null;
    private List<GameObject> Bosses = null;

    int ind = 0;
    string _difficulty;
    public GameObject[] HERO_PREFAB; //0 = heifetz, 1 = hyacinth, 2 = aria
    private float HyacinthSlowPercentage;

    //제너럴에서 호출하며, 난이도, 스테이지 종류를 입력받아 생성할 몬스터들을 정의.
    public void Constructor(string field, string difficulty)
    {
        _difficulty = difficulty;

        switch (PlayerPrefs.GetString("HERO_SELECTED", "HEIFETZ"))
        {
            case "HEIFETZ":
                GameObject HEIFETZ = (GameObject)Instantiate(HERO_PREFAB[0]);
                HyacinthSlowPercentage = 1f;
                break;
            case "HYACINTH":
                GameObject HYCINTH = (GameObject)Instantiate(HERO_PREFAB[1]);
                switch (PlayerPrefs.GetInt("HYACINTH_STAR", 0))
                {
                    case 0:
                        HyacinthSlowPercentage = 0.98f;
                        break;
                    case 1:
                        HyacinthSlowPercentage = 0.96f;
                        break;
                    case 2:
                        HyacinthSlowPercentage = 0.94f;
                        break;
                    case 3:
                        HyacinthSlowPercentage = 0.92f;
                        break;
                }
                break;
            case "ARIA":
                GameObject ARIA = (GameObject)Instantiate(HERO_PREFAB[2]);
                HyacinthSlowPercentage = 1f;
                break;
            default:
                break;
        }

        switch (difficulty)
        {
            //난이도에 따라 몬스터 체력, 난이도, 라운드 수 조정
            case "EASY":
                maxRound = 15;
                enemySpeed = 1f;
                enemyHealth = 200;
                enemyHealth_Q2 = 600;
                enemyHealth_Q3 = 1500;
                monsterPerRound = 15;
                monsterPerRound_Q2 = 20;
                monsterPerRound_Q3 = 25;
                monsterReloadTime = 2f;
                monsterReloadTime_Q2 = 1.5f;
                monsterReloadTime_Q3 = 1f;
                break;
            case "NORMAL":
                maxRound = 20;
                enemySpeed = 1f;
                enemyHealth = 220;
                enemyHealth_Q2 = 660;
                enemyHealth_Q3 = 1700;
                enemyHealth_Q4 = 2500;
                monsterPerRound = 15;
                monsterPerRound_Q2 = 20;
                monsterPerRound_Q3 = 25;
                monsterPerRound_Q4 = 30;
                monsterReloadTime = 2f;
                monsterReloadTime_Q2 = 1.5f;
                monsterReloadTime_Q3 = 1.3f;
                monsterReloadTime_Q4 = 1.1f;
                break;
            case "HARD":
                maxRound = 25;
                enemySpeed = 1f;
                enemyHealth = 230;
                enemyHealth_Q2 = 750;
                enemyHealth_Q3 = 2500;
                enemyHealth_Q4 = 3200;
                enemyHealth_Q5 = 4300;
                monsterPerRound = 15;
                monsterPerRound_Q2 = 20;
                monsterPerRound_Q3 = 25;
                monsterPerRound_Q4 = 30;
                monsterPerRound_Q5 = 30;
                monsterReloadTime = 2f;
                monsterReloadTime_Q2 = 1.5f;
                monsterReloadTime_Q3 = 1.3f;
                monsterReloadTime_Q4 = 1.1f;
                monsterReloadTime_Q5 = 1f;
                break;
            case "INSANE":
                maxRound = 25;
                enemySpeed = 1.5f;
                enemyHealth = 240;
                enemyHealth_Q2 = 1000;
                enemyHealth_Q3 = 2800;
                enemyHealth_Q4 = 4000;
                enemyHealth_Q5 = 6900;
                monsterPerRound = 15;
                monsterPerRound_Q2 = 20;
                monsterPerRound_Q3 = 25;
                monsterPerRound_Q4 = 30;
                monsterPerRound_Q5 = 30;
                monsterReloadTime = 2f;
                monsterReloadTime_Q2 = 1.5f;
                monsterReloadTime_Q3 = 1.3f;
                monsterReloadTime_Q4 = 1.1f;
                monsterReloadTime_Q5 = 1f;
                break;
            case "HELL":
                maxRound = 30;
                enemySpeed = 1.5f;
                enemyHealth = 350;
                enemyHealth_Q2 = 1300;
                enemyHealth_Q3 = 3500;
                enemyHealth_Q4 = 5000;
                enemyHealth_Q5 = 8000;
                monsterPerRound = 15;
                monsterPerRound_Q2 = 20;
                monsterPerRound_Q3 = 25;
                monsterPerRound_Q4 = 30;
                monsterPerRound_Q5 = 30;
                monsterReloadTime = 2f;
                monsterReloadTime_Q2 = 1.5f;
                monsterReloadTime_Q3 = 1.3f;
                monsterReloadTime_Q4 = 1.1f;
                monsterReloadTime_Q5 = 1f;
                break;

        }


        endRound.text = "/"+maxRound.ToString();

        roundTime = monsterReloadTime * monsterPerRound + 5f;

        monsters = new List<GameObject>();
        Bosses = new List<GameObject>();

    
        switch(PlayerPrefs.GetString("FIELD", "SKYVALLEY"))
        {
            case "SKYVALLEY":
                ind = 0;
                break;
            case "FIREFLYSWAMP":
                ind = 4;
                break;
            case "CAVE":
                ind = 8;
                break;
        }
        for(int i = ind; i < ind+4; i++)
        {
            for(int j = 0; j < 40; j++)
            {
                GameObject mst = (GameObject)Instantiate(EnemyArrays[i]);
                mst.transform.SetParent(spawnedMonstersBox.transform);
                mst.GetComponent<EnemyMoving>().speed *= HyacinthSlowPercentage;
                mst.SetActive(false);
                monsters.Add(mst);
            }
        }
    
    }

    public void Constructor_INFINITY()
    {
        switch (PlayerPrefs.GetString("HERO_SELECTED", "HEIFETZ"))
        {
            case "HEIFETZ":
                GameObject HEIFETZ = (GameObject)Instantiate(HERO_PREFAB[0]);
                HyacinthSlowPercentage = 1f;
                break;
            case "HYACINTH":
                GameObject HYCINTH = (GameObject)Instantiate(HERO_PREFAB[1]);
                HyacinthSlowPercentage = 0.98f;
                break;
            case "ARIA":
                GameObject ARIA = (GameObject)Instantiate(HERO_PREFAB[2]);
                HyacinthSlowPercentage = 1f;
                break;
            default:
                break;
        }

        maxRound = 300;
        enemySpeed = 1f;
        enemyHealth = 200;
        monsterPerRound = 20;
        monsterReloadTime = 1.2f;
         

        roundTime = monsterReloadTime * monsterPerRound + 5f;

        monsters = new List<GameObject>();
        Bosses = new List<GameObject>();

        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject mst = (GameObject)Instantiate(EnemyArrays[i]);
                mst.transform.SetParent(spawnedMonstersBox.transform);
                mst.GetComponent<EnemyMoving>().speed *= HyacinthSlowPercentage;
                mst.SetActive(false);
                monsters.Add(mst);
            }
        }

        endRound.text = "/∞"; 

    }

    int i = 1;
    public IEnumerator Playing_INFINITY()
    {
        float instantiate_position = 0f;
        float healthMultiplier = 0.1f;

        for (int i = 0; i < 5; i++)
        {
            string unit;
            int randomUnit = Random.Range(0, 7);
            switch (randomUnit)
            {
                case 0:
                    unit = "Ray";
                    break;
                case 1:
                    unit = "Vird";
                    break;
                case 2:
                    unit = "Eli";
                    break;
                case 3:
                    unit = "Ray";
                    break;
                case 4:
                    unit = "Vird";
                    break;
                case 5:
                    unit = "Eli";
                    break;
                default:
                    unit = "Theis";
                    break;
            }
            MainController.Instance.PaletteRefresh(unit, 1);
        }

        for (i = 1; i <= 300; i++)
        {
            var wait = new WaitForSeconds(monsterReloadTime);
            round.text = currentRound.ToString();
            if (currentRound >= 100)
                round.fontSize = 44;

            if (!currentRound.Equals(1))
            {
                for (int i = 0; i < 2; i++)
                {
                    string unit;
                    int randomUnit = Random.Range(0, 8);
                    switch (randomUnit)
                    {
                        case 0:
                            unit = "Ray";
                            break;
                        case 1:
                            unit = "Vird";
                            break;
                        case 2:
                            unit = "Eli";
                            break;
                        case 3:
                            unit = "Ray";
                            break;
                        case 4:
                            unit = "Vird";
                            break;
                        case 5:
                            unit = "Eli";
                            break;
                        case 6:
                            unit = "Eli";
                            break;
                        default:
                            unit = "Theis";
                            break;
                    }
                    MainController.Instance.PaletteRefresh(unit, 1);
                }
            }


            SoundEffectController.Instance.RoundStartSound();
            yield return new WaitForSeconds(1f);
            Round_X.SetActive(false);


            float stairZ = 0f;
            if ((currentRound % 5).Equals(0))
            {
                if (currentRound.Equals(30))
                {
                    enemyHealth = 4500;

                    if (PlayerPrefs.GetInt("30R_ACHIEVE").Equals(0))
                        PlayerPrefs.SetInt("30R_ACHIEVE", 1);

                    enemySpeed = 1.3f;
                }
                else if (currentRound.Equals(50))
                {
                    enemyHealth = 30000;
                    healthMultiplier = 0.05f;

                    enemySpeed = 1.5f;

                    if (PlayerPrefs.GetInt("50R_ACHIEVE").Equals(0))
                        PlayerPrefs.SetInt("50R_ACHIEVE", 1);
                }
                else if (currentRound.Equals(70))
                {
                    if (PlayerPrefs.GetInt("70R_ACHIEVE").Equals(0))
                        PlayerPrefs.SetInt("70R_ACHIEVE", 1);

                    enemyHealth = 80000;
                    enemySpeed = 1.7f;
                }
                else if(currentRound.Equals(100))
                {
                    enemyHealth = 250000;
                    enemySpeed = 2.1f;
                }

                GameObject spawnBoss = GameObject.Instantiate(BossArrays[3]) as GameObject;
                spawnBoss.transform.SetParent(spawnedMonstersBox.transform);
                spawnBoss.transform.localScale = new Vector3(0.6f, 0.6f);
                spawnBoss.transform.position = new Vector3(-12.5f, -1.5f);
                spawnBoss.GetComponent<BossScript>().health = enemyHealth * 18;
                spawnBoss.GetComponent<BossScript>().speed = enemySpeed * HyacinthSlowPercentage;


                yield return new WaitForSeconds(roundTime - 5f);
            }
            else
            {
                for (int j = 1; j <= monsterPerRound; j++)
                {
                    float z = 0f;

                    //좌표정하기

                    int random1;

                    random1 = Random.Range(1, 6);


                    switch (random1)
                    {
                        case 1:
                            instantiate_position = -4.5f;
                            z = 1f;
                            break;
                        case 2:
                            instantiate_position = -3f;
                            z = 0.99f;
                            break;
                        case 3:
                            instantiate_position = -1.5f;
                            z = 0.98f;
                            break;
                        case 4:
                            instantiate_position = 0f;
                            z = 0.97f;
                            break;
                        case 5:
                            instantiate_position = 1.5f;
                            z = 0.96f;
                            break;

                    }

                    int searchIndexLow = 0, searchIndexMax = 110;

                    int MonsterSearch = Random.Range(searchIndexLow, searchIndexMax);
                    GameObject ActiveMonster = monsters[MonsterSearch];
                    while (ActiveMonster.activeInHierarchy.Equals(true))
                    {
                        MonsterSearch = Random.Range(searchIndexLow, searchIndexMax);
                        ActiveMonster = monsters[MonsterSearch];
                    }
                    ActiveMonster.transform.localPosition = new Vector3(-12.5f, instantiate_position, z + stairZ);
                    Transform a = ActiveMonster.GetComponent<EnemyMoving>().hpBar.transform;
                    ActiveMonster.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
                    ActiveMonster.GetComponent<EnemyMoving>().textMesh.text = enemyHealth.ToString();
                    ActiveMonster.GetComponent<EnemyMoving>().hpBar.transform.localPosition = new Vector3(0, a.localPosition.y, a.localPosition.z);
                    ActiveMonster.GetComponent<EnemyMoving>().hpBar.transform.localScale = new Vector3(1.38f, a.localScale.y, a.localScale.z);
                    ActiveMonster.GetComponent<EnemyMoving>().health = enemyHealth;
                    ActiveMonster.GetComponent<EnemyMoving>().currentHealth = enemyHealth;
                    ActiveMonster.GetComponent<EnemyMoving>().speed = enemySpeed * HyacinthSlowPercentage;

                    ActiveMonster.SetActive(true);


                    stairZ -= 0.001f;

                    yield return wait;
                }
            }
            enemyHealth += (int)(enemyHealth * healthMultiplier);
  


            currentRound++;
            yield return new WaitForSeconds(4f);

            roundTime = monsterReloadTime * monsterPerRound + 5f;
        }


        yield return null;
    }

    public IEnumerator Playing()
    {

        float instantiate_position = 0f;
      
        
        for (int i = 0; i < 5; i++)
        {
            string unit;
            int randomUnit = Random.Range(0, 7);
            switch (randomUnit)
            {
                case 0:
                    unit = "Ray";
                    break;
                case 1:
                    unit = "Vird";
                    break;
                case 2:
                    unit = "Eli";
                    break;
                case 3:
                    unit = "Ray";
                    break;
                case 4:
                    unit = "Vird";
                    break;
                case 5:
                    unit = "Eli";
                    break;
                default:
                    unit = "Theis";
                    break;
            }
            MainController.Instance.PaletteRefresh(unit, 1);
        }

        for (i = 1; i <= maxRound; i++)
        {
             var wait = new WaitForSeconds(monsterReloadTime);
            round.text = currentRound.ToString();

            if (!currentRound.Equals(1))
            {
                for (int i = 0; i < 2; i++)
                {
                    string unit;
                    int randomUnit = Random.Range(0, 8);
                    switch (randomUnit)
                    {
                        case 0:
                            unit = "Ray";
                            break;
                        case 1:
                            unit = "Vird";
                            break;
                        case 2:
                            unit = "Eli";
                            break;
                        case 3:
                            unit = "Ray";
                            break;
                        case 4:
                            unit = "Vird";
                            break;
                        case 5:
                            unit = "Eli";
                            break;
                        case 6:
                            unit = "Eli";
                            break;
                        default:
                            unit = "Theis";
                            break;
                    }
                    MainController.Instance.PaletteRefresh(unit, 1);
                }
            }

            SoundEffectController.Instance.RoundStartSound();
            Round_X.GetComponent<SpriteRenderer>().sprite = roundSprite[i - 1];
            Round_X.SetActive(true);
            yield return new WaitForSeconds(1f);
            Round_X.SetActive(false);


            float stairZ = 0f;
            int bosInd = 0;
            if ((currentRound%5).Equals(0))
            {
                switch (ind)
                {
                    case 0:
                        bosInd = 0;
                        break;
                    case 4:
                        bosInd = 1;
                        break;
                    case 8:
                        bosInd = 2;
                        break;
                }
                GameObject spawnBoss = GameObject.Instantiate(BossArrays[bosInd]) as GameObject;
                spawnBoss.transform.SetParent(spawnedMonstersBox.transform);
                spawnBoss.transform.localScale = new Vector3(0.6f, 0.6f);
                spawnBoss.transform.position = new Vector3(-12.5f, -1.5f);
                spawnBoss.GetComponent<BossScript>().health = enemyHealth * (currentRound+6);
                spawnBoss.GetComponent<BossScript>().speed = enemySpeed * HyacinthSlowPercentage;
                if (currentRound.Equals(maxRound))
                    spawnBoss.GetComponent<BossScript>().IsLastBoss();

                yield return new WaitForSeconds(roundTime -5f);
            }
            else
            {
                for (int j = 1; j <= monsterPerRound; j++)
                {
                    float z = 0f;

                    //좌표정하기

                    int random1;

                    random1 = Random.Range(1, 6);


                    switch (random1)
                    {
                        case 1:
                            instantiate_position = -4.5f;
                            z = 1f;
                            break;
                        case 2:
                            instantiate_position = -3f;
                            z = 0.99f;
                            break;
                        case 3:
                            instantiate_position = -1.5f;
                            z = 0.98f;
                            break;
                        case 4:
                            instantiate_position = 0f;
                            z = 0.97f;
                            break;
                        case 5:
                            instantiate_position = 1.5f;
                            z = 0.96f;
                            break;

                    }

                    int searchIndexLow = 0, searchIndexMax = 40;

                    if(currentRound < 5)
                    {
                        searchIndexLow = 0;
                        searchIndexMax = 40;
                    }
                    else if (5 <= currentRound && currentRound < 10)
                    {
                        searchIndexLow = 40;
                        searchIndexMax = 80;
                    }
                    else if (10 <= currentRound && currentRound < 15)
                    {
                        searchIndexLow = 80;
                        searchIndexMax = 120;
                    }
                    else
                    {
                        searchIndexLow = 120;
                        searchIndexMax = 160;
                    }

                    int MonsterSearch = Random.Range(searchIndexLow, searchIndexMax);
                    GameObject ActiveMonster = monsters[MonsterSearch];
                    while (ActiveMonster.activeInHierarchy.Equals(true))
                    {
                        MonsterSearch = Random.Range(searchIndexLow, searchIndexMax);
                        ActiveMonster = monsters[MonsterSearch];
                    }
                    ActiveMonster.transform.localPosition = new Vector3(-12.5f, instantiate_position, z + stairZ);
                    Transform a = ActiveMonster.GetComponent<EnemyMoving>().hpBar.transform;
                    ActiveMonster.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
                    ActiveMonster.GetComponent<EnemyMoving>().textMesh.text = enemyHealth.ToString();
                    ActiveMonster.GetComponent<EnemyMoving>().hpBar.transform.localPosition = new Vector3(0, a.localPosition.y, a.localPosition.z);
                    ActiveMonster.GetComponent<EnemyMoving>().hpBar.transform.localScale = new Vector3(1.38f, a.localScale.y, a.localScale.z);
                    ActiveMonster.GetComponent<EnemyMoving>().health = enemyHealth;
                    ActiveMonster.GetComponent<EnemyMoving>().currentHealth = enemyHealth;
                    ActiveMonster.GetComponent<EnemyMoving>().speed = enemySpeed * HyacinthSlowPercentage;

                    ActiveMonster.SetActive(true);
 

                    stairZ -= 0.001f;

                    yield return wait;
                }
            }
            enemyHealth += (int)(enemyHealth * 0.05);
            if(currentRound.Equals(5))
            {
                enemyHealth = enemyHealth_Q2;
                monsterPerRound = monsterPerRound_Q2;
                monsterReloadTime = monsterReloadTime_Q2;
                wait = new WaitForSeconds(monsterReloadTime);
            }
            else if(currentRound.Equals(10))
            {
                enemyHealth = enemyHealth_Q3;
                monsterPerRound = monsterPerRound_Q3;
                monsterReloadTime = monsterReloadTime_Q3;
                wait = new WaitForSeconds(monsterReloadTime);
            }
            else if (currentRound.Equals(15))
            {
                enemyHealth = enemyHealth_Q4;
                monsterPerRound = monsterPerRound_Q4;
                monsterReloadTime = monsterReloadTime_Q4;
                wait = new WaitForSeconds(monsterReloadTime);
            }
            else if (currentRound.Equals(20))
            {
                enemyHealth = enemyHealth_Q5;
                monsterPerRound = monsterPerRound_Q5;
                monsterReloadTime = monsterReloadTime_Q5;
                wait = new WaitForSeconds(monsterReloadTime);
            }

            else { }
            
            currentRound++;
            yield return new WaitForSeconds(4f);

            roundTime = monsterReloadTime * monsterPerRound + 5f;
        }
        
        yield return null;
        
    }

    private void FixedUpdate()
    {
        {
            gage.value += Time.deltaTime * (1 /  roundTime);
            if (gage.value.Equals(1))
            {
                if (currentRound < maxRound)
                {
                    gage.value = 0;
                }
                else
                {
                    gage.value = 1;
                }
            }
        }

  
    }


}
