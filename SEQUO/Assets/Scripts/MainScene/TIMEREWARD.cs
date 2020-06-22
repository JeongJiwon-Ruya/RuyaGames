using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIMEREWARD : MonoBehaviour
{
    public GameObject Fairy;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("DAILYAD_REWARD").Equals(5))
            PlayerPrefs.SetInt("DAILYAD_REWARD", 1);
        else
        {
            PlayerPrefs.SetInt("DAILYAD_REWARD", 0);
        }
        if (Season_Coordinate_Controller.Instance.seasonInfoForReward.Equals(""))
        {}
        else
        {
            //0 = 연도    1 = 달   2 = 날짜      3 = 시       4 = 분
            string BeforeSplit_past_time = PlayerPrefs.GetString("TIME");


            string[] past_time = BeforeSplit_past_time.Split('-');
            string[] current_time = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm").Split('-');

        
                if (past_time[1].Equals(current_time[1]))
                {
                    //일이 다르면
                    if ((int.Parse(current_time[2]) - int.Parse(past_time[2])) > 0)
                    {
                        Debug.Log("a");
                        PlayerPrefs.SetInt("DAYLYAD_REWARD", 1);

                        for (int i = 0; i < 7; i++)
                        {
                            GameObject newFairy = GameObject.Instantiate(Fairy) as GameObject;
                            newFairy.transform.SetParent(GameObject.Find("Fairys").transform);
                            newFairy.transform.localPosition = new Vector3(Random.Range(-911, 1020), Random.Range(-211, 380));
                        }
                        return;
                    }
                    //일이 같으면
                    else
                    {

                        int timegap = int.Parse(current_time[3]) - int.Parse(past_time[3]);

                        if ((timegap % 3) < 7)
                        {
                            for (int i = 0; i < timegap % 3; i++)
                            {
                                GameObject newFairy = GameObject.Instantiate(Fairy) as GameObject;
                                newFairy.transform.parent = GameObject.Find("Fairys").transform;
                                newFairy.transform.localPosition = new Vector3(Random.Range(-911, 1020), Random.Range(-211, 380));
                            }
                            return;
                        }
                        else
                        {
                            for (int i = 0; i < 7; i++)
                            {
                                GameObject newFairy = GameObject.Instantiate(Fairy) as GameObject;
                                newFairy.transform.parent = GameObject.Find("Fairys").transform;
                                newFairy.transform.localPosition = new Vector3(Random.Range(-911, 1020), Random.Range(-211, 380));
                            }
                            return;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 7; i++)
                    {
                        GameObject newFairy = GameObject.Instantiate(Fairy) as GameObject;
                        newFairy.transform.SetParent(GameObject.Find("Fairys").transform);
                        newFairy.transform.localPosition = new Vector3(Random.Range(-911, 1020), Random.Range(-211, 380));
                    }
                    return;
                }
            
            //달이 같으면
  
        }

        PlayerPrefs.SetString("TIME", System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm"));

    }
    
}
