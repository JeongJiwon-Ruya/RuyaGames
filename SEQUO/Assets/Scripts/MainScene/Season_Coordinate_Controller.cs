using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Season_Coordinate_Controller : MonoBehaviour
{
    //32개,   (0,0) = 0 (1,0) = 1 (0,1) = 16
    public Button[] CoordinateButtons;
    //깔리는 꽃들
    public GameObject[] Flowers;
    //꽃들 모아놓는 사전 (Flower_Dic은 이미지 컴포넌트 저장용, flower_dic은 인덱스 사용하려고 만든것)
    public GameObject[] Flower_Dic;
    Dictionary<int, string> flower_dic;

    public GameObject[] SeasonBackGround;

    public int season_Num;

    //Singleton
    protected static Season_Coordinate_Controller instance = null;
    public static Season_Coordinate_Controller Instance
    {
        get
        {
            instance = FindObjectOfType(typeof(Season_Coordinate_Controller)) as Season_Coordinate_Controller;

            if (instance == null)
            {
                instance = new GameObject("@" + typeof(Season_Coordinate_Controller).ToString(), typeof(Season_Coordinate_Controller)).AddComponent<Season_Coordinate_Controller>();
                DontDestroyOnLoad(instance);
            }
            return instance;
        }
    }

    bool[,] Coordinate;
    int[] season_count;

    public string seasonInfoForReward;

    public string flower_selected;

    private void Awake()
    {
        flower_dic = new Dictionary<int, string>();

       for(int i = 0; i < Flower_Dic.Length; i++)
        {
            flower_dic.Add(i, Flower_Dic[i].name);
        }
        season_count = new int[4];
        Coordinate = new bool[16, 2];

        int flow_C = 0;
        bool done = false;
        for (int i = 0; i < 2; i++)
        {
            for(int j = 0; j < 16; j++)
            {
                string flw = PlayerPrefs.GetString("FLOWERCO_(" + j + "," + i + ")","");
                if (flw.Equals(""))
                    Coordinate[j, i] = false;
                else
                {
                    int indexOfDic = 0;
                    for (int k = 0; k < Flower_Dic.Length; k++)
                    {
                        string[] ab = Flower_Dic[k].name.Split('_');
                        string c = ab[1];
                        if (c.Equals(flw))
                        {
                            indexOfDic = k;
                            break;
                        }
                    }
                    Coordinate[j, i] = true;
                    string[] a = Flower_Dic[indexOfDic].name.Split('_');
                    SeasonInputer(a[0],true);
                    done = true;
                    Flowers[flow_C].GetComponent<Image>().enabled = true;
                    Flowers[flow_C].GetComponent<Image>().sprite = Flower_Dic[indexOfDic].GetComponent<SpriteRenderer>().sprite;
                    Flowers[flow_C].GetComponent<Image>().SetNativeSize();
                }
                flow_C++;
            }
        }
        if (!done)
        {
            BGMController.Instance.ReceiveData(4);
        }

    }


    public void SeasonInputer(string season, bool plusOrMinus)
    {
        if (plusOrMinus)
        {
            switch (season)
            {
                case "SPRING":
                    season_count[0]++;
                    break;
                case "SUMMER":
                    season_count[1]++;
                    break;
                case "AUTUMN":
                    season_count[2]++;
                    break;
                case "WINTER":
                    season_count[3]++;
                    break;
            }
        }
        else
        {
            switch (season)
            {
                case "SPRING":
                    season_count[0]--;
                    break;
                case "SUMMER":
                    season_count[1]--;
                    break;
                case "AUTUMN":
                    season_count[2]--;
                    break;
                case "WINTER":
                    season_count[3]--;
                    break;
            }
        }

        int temp = 0;
        for(int i = 1; i < 4; i++)
        {
            if(season_count[temp] >= season_count[i])
            {
            }
            else if (season_count[temp] < season_count[i])
            {
                temp = i;
            }
        }

        if(season_count[temp] >= 7)
        {
            switch (temp)
            {
                case 0:
                    //봄
                    seasonInfoForReward = "spring";

                    season_Num = 0;
                    SeasonBackGround[0].SetActive(true);
                    SeasonBackGround[1].SetActive(false);
                    SeasonBackGround[2].SetActive(false);
                    SeasonBackGround[3].SetActive(false);
                    SeasonBackGround[4].SetActive(false);
                    BGMController.Instance.ReceiveData(0);
                    break;
                case 1:
                    seasonInfoForReward = "summer";

                    season_Num = 1;
                    SeasonBackGround[0].SetActive(false);
                    SeasonBackGround[1].SetActive(true);
                    SeasonBackGround[2].SetActive(false);
                    SeasonBackGround[3].SetActive(false);
                    SeasonBackGround[4].SetActive(false);
                    BGMController.Instance.ReceiveData(1);
                    break;
                case 2:
                    seasonInfoForReward = "autumn";

                    season_Num = 2;
                    SeasonBackGround[0].SetActive(false);
                    SeasonBackGround[1].SetActive(false);
                    SeasonBackGround[2].SetActive(true);
                    SeasonBackGround[3].SetActive(false);
                    SeasonBackGround[4].SetActive(false);
                    BGMController.Instance.ReceiveData(2);
                    break;
                case 3:
                    seasonInfoForReward = "fall";

                    season_Num = 3;
                    SeasonBackGround[0].SetActive(false);
                    SeasonBackGround[1].SetActive(false);
                    SeasonBackGround[2].SetActive(false);
                    SeasonBackGround[3].SetActive(true);
                    SeasonBackGround[4].SetActive(false);
                    BGMController.Instance.ReceiveData(3);
                    break;
                default:
                  //  BGMController.Instance.StopBgm();
                    break;
            }
        }
        else
        {
            
            BGMController.Instance.ReceiveData(4);
            SeasonBackGround[0].SetActive(false);
            SeasonBackGround[1].SetActive(false);
            SeasonBackGround[2].SetActive(false);
            SeasonBackGround[3].SetActive(false);
            SeasonBackGround[4].SetActive(true);
        }
    }
    public void ApplyFlower(string flowerName)
    {
        //여는 과정
        int BtnIndex = 0;
        for(int i = 0; i < 2; i++)
        {
            for(int j = 0; j < 16; j++)
            {
                if (!Coordinate[j, i])
                {
                    CoordinateButtons[BtnIndex].interactable = true;
                    CoordinateButtons[BtnIndex].GetComponent<Image>().enabled = true;
                    CoordinateButtons[BtnIndex].GetComponent<CoordinateButton>().RoleAssign("APPLY");
                }
                BtnIndex++;
            }
        }

        flower_selected = flowerName;


    }
    public void DeleteFlower()
    {
        int BtnIndex = 0;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                if (Coordinate[j, i])
                {
                    CoordinateButtons[BtnIndex].interactable = true;
                    CoordinateButtons[BtnIndex].GetComponent<Image>().enabled = true;
                    CoordinateButtons[BtnIndex].GetComponent<CoordinateButton>().RoleAssign("DELETE");
                }
                BtnIndex++;
            }
        }
    }
    public bool ApplyProcess(int x, int y)
    {
        if (Coordinate[x, y])
        {
            return false;
        }
        else
        {
            Coordinate[x, y] = true;
         

            int indexOfDic = 0;
            for (int k=0; k<flower_dic.Count; k++)
            {
                string[] st = flower_dic[k].Split('_');
                string b = st[1];
                if (flower_selected.Equals(b))
                {
                    indexOfDic = k;
                    break;
                }
            }

            int flow_C = 0;
            if (y.Equals(0))
                flow_C = x;
            else
                flow_C = x + 16;

            string[] a = Flower_Dic[indexOfDic].name.Split('_');
            SeasonInputer(a[0],true);
            Flowers[flow_C].GetComponent<Image>().enabled = true;
            Flowers[flow_C].GetComponent<Image>().sprite = Flower_Dic[indexOfDic].GetComponent<SpriteRenderer>().sprite;
            Flowers[flow_C].GetComponent<Image>().SetNativeSize();

            PlayerPrefs.SetString("FLOWERCO_(" + x + "," + y + ")", a[1]);


            ProcessEnd();
            return true;
        }
    }
    public bool DeleteProcess(int x, int y)
    {
        if (Coordinate[x, y])
        {
            if (y.Equals(0))
                Flowers[x].GetComponent<Image>().enabled = false;
            else
                Flowers[x + 16].GetComponent<Image>().enabled = false;

            string flw = PlayerPrefs.GetString("FLOWERCO_(" + x + "," + y + ")");
            
            int indexOfDic = 0;
            for (int k = 0; k < Flower_Dic.Length; k++)
            {
                string[] aw = Flower_Dic[k].name.Split('_');
                string aew = aw[1];
                if (aw[1].Equals(flw))
                {
                    indexOfDic = k;
                    break;
                }
            }
            
            int flow_C = 0;
            if (y.Equals(0))
                flow_C = x;
            else
                flow_C = x + 16;


            string[] a = Flower_Dic[indexOfDic].name.Split('_');

            PlayerPrefs.SetInt(a[1] + "_COUNT", PlayerPrefs.GetInt(a[1] + "_COUNT") + 1);

            PlayerPrefs.SetString("FLOWERCO_(" + x + "," + y + ")", "");
            SeasonInputer(a[0], false);
            Flowers[flow_C].GetComponent<Image>().enabled = false;

            Coordinate[x, y] = false;
            ProcessEnd();

            return true;
        }
        else
        {
            return false;
        }
    }
    public void ProcessEnd()
    {
        for(int i = 0; i < CoordinateButtons.Length; i++)
        {
            CoordinateButtons[i].GetComponent<Image>().enabled = false;
            CoordinateButtons[i].interactable = false;
            flower_selected = null;
        }
    }

}
