using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoordinateButton : MonoBehaviour
{
    int x, y;
    bool isSeted;
    Button ownB;

    //true = Apply, false = Delete
    bool role;

    private void Awake()
    {
        string[] x_y = gameObject.name.Split(',');
        x = int.Parse(x_y[0]);
        y = int.Parse(x_y[1]);

        ownB = GetComponent<Button>();
    }

    private void Start()
    {
        ownB.onClick.AddListener(ButtonClicked);
    }

    public void RoleAssign(string roleS)
    {
        if (roleS.Equals("APPLY"))
            role = true;
        else
            role = false;
    }

    string flower_select;

    public void ButtonClicked()
    {
        flower_select = Season_Coordinate_Controller.Instance.flower_selected;

        if (role)
            ApplyRole();
        else
            DeleteRole();
    }

    public void ApplyRole()
    {
        if (Season_Coordinate_Controller.Instance.ApplyProcess(x, y))
        {
            PlayerPrefs.SetInt(flower_select+"_COUNT", PlayerPrefs.GetInt(flower_select+"_COUNT") - 1);
            Season_Coordinate_Controller.Instance.ProcessEnd();
        }
        else
        {
            Season_Coordinate_Controller.Instance.ProcessEnd();
        }

    }
    public void DeleteRole()
    {


        if (Season_Coordinate_Controller.Instance.DeleteProcess(x, y))
        {
        //    GetComponent<Image>().sprite = null;
            PlayerPrefs.SetInt(flower_select + "_COUNT", PlayerPrefs.GetInt(flower_select + "_COUNT") + 1);

            //꽃 정보 입력받아서 좌표에서 지우기


            Season_Coordinate_Controller.Instance.ProcessEnd();
        }
        else
        {
            Season_Coordinate_Controller.Instance.ProcessEnd();
        }
    }
}
