using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public GameObject GameOverPopup;
    public GameObject GameOverPopup_INFINITY;
    public GameObject GameClearPopup;

    [Header("지역정보에따른 배경변화")]
    public GameObject JandiBat;
    public GameObject BackGround;
    public Sprite[] grass;
    public Sprite[] outdoor;

    protected static MainController instance = null;
    public static MainController Instance
    {
        get
        {
            instance = FindObjectOfType(typeof(MainController)) as MainController;

            if (instance == null)
            {
                instance = new GameObject("@" + typeof(MainController).ToString(), typeof(MainController)).AddComponent<MainController>();
            }
            return instance;
        }
    }

    public Dictionary<string, int> UnitCount;

    
    public GameObject EGM_G;
    private EnemyGeneratingMachine_Game enemyGeneratingMachine_Game;

    public GameObject Content;

    public int treasureboxCount = 0;
    private bool merced = false;
    public void MercedIsHere()
    {
        merced = true;
    }
    public bool Merced()
    {
        return merced;
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        GameOverPopup.SetActive(true);
    }

    public void GameOver_INFINITY()
    {
        Time.timeScale = 0f;
        if(PlayerPrefs.GetInt("INFINITY_RECORD") < EGM_G.GetComponent<EnemyGeneratingMachine_Game>().currentRound)
            PlayerPrefs.SetInt("INFINITY_RECORD", EGM_G.GetComponent<EnemyGeneratingMachine_Game>().currentRound);
        GameOverPopup_INFINITY.SetActive(true);
    }
    public void GameClear()
    {
        GameClearPopup.SetActive(true);
        SoundEffectController.Instance.GameClearSound();
        DifficultyClear();
    }


    public void DifficultyClear()
    {
        switch (PlayerPrefs.GetString("DIFFICULTY"))
        {
            case ("EASY"):
                PlayerPrefs.SetInt("NORMAL_CLEAR", 1);
                if (PlayerPrefs.GetInt("EASY_ACHIEVE").Equals(0))
                    PlayerPrefs.SetInt("EASY_ACHIEVE", 1);
                break;
            case ("NORMAL"):
                PlayerPrefs.SetInt("HARD_CLEAR", 1);
                if (PlayerPrefs.GetInt("NORMAL_ACHIEVE").Equals(0))
                    PlayerPrefs.SetInt("NORMAL_ACHIEVE", 1);
                break;
            case ("HARD"):
                PlayerPrefs.SetInt("INSANE_CLEAR", 1);
                if (PlayerPrefs.GetInt("HARD_ACHIEVE").Equals(0))
                    PlayerPrefs.SetInt("HARD_ACHIEVE", 1);
                break;
            case ("INSANE"):
                PlayerPrefs.SetInt("HELL_CLEAR",1);
                if (PlayerPrefs.GetInt("INSANE_ACHIEVE").Equals(0))
                    PlayerPrefs.SetInt("INSANE_ACHIEVE", 1);
                break;
            case ("HELL"):
                if (PlayerPrefs.GetInt("HELL_ACHIEVE").Equals(0))
                    PlayerPrefs.SetInt("HELL_ACHIEVE", 1);
                break;
            default:
                Debug.Log("ER");
                break;
        }
    }
    private void Awake()
    {
        enemyGeneratingMachine_Game = EGM_G.GetComponent<EnemyGeneratingMachine_Game>();
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt("MUTE").Equals(0))
        {
            BGMController.Instance.GameStart_BGM();
        }

        //유닛들 정보 입력
        {
            UnitCount = new Dictionary<string, int>();
            UnitCount.Add("Ray", 0);
            UnitCount.Add("Vird", 0);
            UnitCount.Add("Eli", 0);
            UnitCount.Add("Theis", 0);

            //2성
            UnitCount.Add("Cross", 0);
            UnitCount.Add("Terrine", 0);
            UnitCount.Add("Crete", 0);
            UnitCount.Add("Roid", 0);
            UnitCount.Add("May", 0);
            UnitCount.Add("Akina", 0);
            UnitCount.Add("Robin", 0);
            UnitCount.Add("Caster", 0);

            //3성
            UnitCount.Add("Reydn", 0);
            UnitCount.Add("Edel", 0);
            UnitCount.Add("Corona", 0);
            UnitCount.Add("Heith", 0);
            UnitCount.Add("Mad", 0);
            UnitCount.Add("Ghibli", 0);
            UnitCount.Add("Livea", 0);
            UnitCount.Add("Valte", 0);
            UnitCount.Add("Ife", 0);
            UnitCount.Add("Ceta", 0);
            UnitCount.Add("Senn", 0);
            UnitCount.Add("Russel", 0);

            //4성
            UnitCount.Add("Curious", 0);
            UnitCount.Add("Drake", 0);
            UnitCount.Add("Gale", 0);
            UnitCount.Add("HighLander", 0);
            UnitCount.Add("Icarus", 0);
            UnitCount.Add("Lepita", 0);
            UnitCount.Add("Lysithea", 0);
            UnitCount.Add("Merced", 0);
            UnitCount.Add("Nephisto", 0);
            UnitCount.Add("Pluto", 0);
            UnitCount.Add("Prominence", 0);
            UnitCount.Add("Servent", 0);
            UnitCount.Add("Talencia", 0);

            //5성
            UnitCount.Add("Kargos", 0);
            UnitCount.Add("Lephion", 0);
            UnitCount.Add("MeryEl", 0);
            UnitCount.Add("Mido", 0);


            
        }
  
        if(PlayerPrefs.GetString("PLAYMODE").Equals("ADVENTURE"))
        {
            switch(PlayerPrefs.GetString("FIELD", "SKYVALLEY"))
            {
                case "SKYVALLEY":
                    JandiBat.GetComponent<Image>().sprite = grass[0];
                    BackGround.GetComponent<Image>().sprite = outdoor[0];
                    break;
                case "FIREFLYSWAMP":
                    JandiBat.GetComponent<Image>().sprite = grass[1];
                    BackGround.GetComponent<Image>().sprite = outdoor[1];
                    break;
                case "CAVE":
                    JandiBat.GetComponent<Image>().sprite = grass[2];
                    BackGround.GetComponent<Image>().sprite = outdoor[2];
                    break;
            }

            enemyGeneratingMachine_Game.Constructor(PlayerPrefs.GetString("FIELD"), PlayerPrefs.GetString("DIFFICULTY"));
            enemyGeneratingMachine_Game.StartCoroutine(enemyGeneratingMachine_Game.Playing());
        }
        else if (PlayerPrefs.GetString("PLAYMODE").Equals("INFINITY"))
        {
            JandiBat.GetComponent<Image>().sprite = grass[3];
            BackGround.GetComponent<Image>().sprite = outdoor[3];
            enemyGeneratingMachine_Game.Constructor_INFINITY();
            enemyGeneratingMachine_Game.StartCoroutine(enemyGeneratingMachine_Game.Playing_INFINITY());
        }
    }


    public void PaletteRefresh(string unitName, int addValue)
    {
        if (unitName.Equals("null"))
            return;

        //더할때
        if (addValue > 0) 
        {
            UnitCount[unitName] += addValue;
            (Content.transform.Find(unitName).gameObject).transform.GetComponentInChildren<Text>().text = UnitCount[unitName].ToString();
                    

            if(UnitCount[unitName] == 1)
            {
                UnitToSetActive(unitName, true);
            }
               
        }
                //뺄때
        else if( addValue < 0)
        {

            UnitCount[unitName] += addValue;
            (Content.transform.Find(unitName).gameObject).transform.GetComponentInChildren<Text>().text = UnitCount[unitName].ToString();

        }
        //0일때
        else { }
    }

    public void UnitToSetActive(string newUnitName, bool tf)
    {
        Content.transform.Find(newUnitName).gameObject.SetActive(tf);
    }

    public void PaletteCountRefresh(string unitName)
    {

        (Content.transform.Find(unitName).gameObject).transform.GetComponentInChildren<Text>().text = UnitCount[unitName].ToString();
        if (UnitCount[unitName] == 0)
            Content.transform.Find(unitName).gameObject.SetActive(false);
        else
            Content.transform.Find(unitName).gameObject.SetActive(true);
    }

}







    /*
     * 조합창에서 유닛카드 꾹눌렀을때
     * 해당 유닛의 정보를 파악->드롭했을때 파악된 정보 바탕으로 필드에 생성 (드래그 애니메이션, 격자화)
     * 애니메이션 속도 일괄적 조정
     * 라운드가 진행되는 트리거는 시간.
     */
