using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateSystem : MonoBehaviour
{
    protected static CoordinateSystem instance = null;
    public static CoordinateSystem Instance
    {
        get
        {
            instance = FindObjectOfType(typeof(CoordinateSystem)) as CoordinateSystem;

            if(instance == null)
            {
                instance = new GameObject("@" + typeof(CoordinateSystem).ToString(), typeof(CoordinateSystem)).AddComponent<CoordinateSystem>();
            }
            return instance;
        }
    }


    bool[,] unitCoordinate;

    private void Awake()
    {
        unitCoordinate = new bool[3, 5];
    }


    public Vector2 Converter(Vector2 v2)
    {
        float toConvert_X = v2.x;
        float toConvert_Y = v2.y;

        float converted_X = 0f;
        float converted_Y = 0f;

        switch (toConvert_X)
        {
            case 2.4f:
                converted_X = 0f;
                break;
            case 3.9f:
                converted_X = 1f;
                break;
            case 5.4f:
                converted_X = 2f;
                break;
            default:

                break;
        }

        switch (toConvert_Y)
        {
            case 1.5f:
                converted_Y = 0f;
                break;
            case 0f:
                converted_Y = 1f;
                break;
            case -1.5f:
                converted_Y = 2f;
                break;
            case -3f:
                converted_Y = 3f;
                break;
            case -4.5f:
                converted_Y = 4f;
                break;
            default:
                break;
        }


     //   if (converted_X != 0 && converted_Y != 0)
        {
            Vector2 result = new Vector2(converted_X, converted_Y);
            return result;
        }
    }

    public bool EnterProcess(Vector2 vec2, string unitName)
    {


        if (Checking_IsNotExist(vec2))
        {
            UnitEnter(vec2);

            
            MainController.Instance.UnitCount[unitName]--;
            MainController.Instance.PaletteCountRefresh(unitName);


            return true;
        }
        else
            return false;

    }

    public bool EnterProcessForHero(Vector2 vec2, string unitName)
    {
        if (Checking_IsNotExist(vec2))
        {
            UnitEnter(vec2);




            return true;
        }
        else
            return false;
    }

    public void UnitEnter(Vector2 vector2)
    {
        Vector2 newComer = Converter(vector2);
        unitCoordinate[(int)newComer.x, (int)newComer.y] = true;
    }

    public bool Checking_IsNotExist(Vector2 vec_check2)
    {
        Vector2 checker = Converter(vec_check2);
        if (!(unitCoordinate[(int)checker.x, (int)checker.y]))
            return true;
        else
            return false;
    }

    public void ExitProcess(Vector2 vector2, string unitName)
    {
        Vector2 newExiter = Converter(vector2);
        unitCoordinate[(int)newExiter.x, (int)newExiter.y] = false;

        /*
        MainController.Instance.UnitCount[unitName]--;
        MainController.Instance.PaletteCountRefresh(unitName);
        */
    }

}
