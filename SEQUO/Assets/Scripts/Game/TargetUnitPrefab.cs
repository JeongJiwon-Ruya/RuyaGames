using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TargetUnitPrefab : MonoBehaviour
{
    private SpriteRenderer spr;
    public GameObject rayPrefab;
    public GameObject unitcardForMix;
    public Sprite cardSprite;
    public Sprite unitSprite;

    private GameObject mixBox1;
    private GameObject mixBox2;
    private GameObject mixBox3;

    private string unitName;

    private Text nameText;


  //  public CoordinateSystem coordinateSystem;

    // Start is called before the first frame update
    void Start()
    {
        nameText = GameObject.Find("UnitName").GetComponent<Text>();

        spr = GetComponent<SpriteRenderer>();
        transform.localScale = (new Vector3(1f, 1f, 1f));

        unitName = cardSprite.name;

        nameText.text = unitName;
    }

    // Update is called once per frame
    void Update()
    {


        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        if (((1829 <= x && x < 1966) || (1963 <= x && x < 2108) || (2108 <= x && x < 2242)) && (173.8369f <= y && y < 276.1851f))
        {
            spr.sprite = cardSprite;
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        else
        {
            spr.sprite = unitSprite;
            transform.localScale = (new Vector3(1f, 1f, 1f));

        }


        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 16));

        if (Input.GetMouseButtonUp(0))
        {
            float fixedX = 0f;
            float fixedY = 0f;
            float stairZ = 0f;
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
            else if ( 2128 <= x && x < 2222)
            {
                fixedX = 10.331f;   
                xForMix = true;
                xInRange = false;
            }
            else
                xInRange = false;

            //
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



            if (xInRange && yInRange)
            {
               // if (coordinateSystem.EnterProcess(new Vector2(fixedX, fixedY)))

                if(CoordinateSystem.Instance.EnterProcess(new Vector2(fixedX,fixedY),rayPrefab.name))
                {
                    float xStair;
                    switch (rayPrefab.tag)
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
                    GameObject new1 = GameObject.Instantiate(rayPrefab, new Vector3(fixedX, fixedY + xStair, stairZ), Quaternion.identity) as GameObject;
                }
                    

            }
            else if(xForMix && yForMix)
            {

                mixBox1 = GameObject.Find("MixBox1");
                mixBox2 = GameObject.Find("MixBox2");
                mixBox3 = GameObject.Find("MixBox3");

                if (fixedX == 7.572f)
                {
                    if (mixBox1.GetComponent<SpriteRenderer>().sprite == null)
                    {
                        mixBox1.GetComponent<SpriteRenderer>().sprite = Resources.Load(unitName, typeof(Sprite)) as Sprite;
                        MainController.Instance.UnitCount[mixBox1.GetComponent<SpriteRenderer>().sprite.name]--;
                        MainController.Instance.PaletteCountRefresh(mixBox1.GetComponent<SpriteRenderer>().sprite.name);
                    }
                }
                else if (fixedX == 8.949f)
                {
                    if (mixBox2.GetComponent<SpriteRenderer>().sprite == null)
                    {
                        mixBox2.GetComponent<SpriteRenderer>().sprite = Resources.Load(unitName, typeof(Sprite)) as Sprite;
                        MainController.Instance.UnitCount[mixBox2.GetComponent<SpriteRenderer>().sprite.name]--;
                        MainController.Instance.PaletteCountRefresh(mixBox2.GetComponent<SpriteRenderer>().sprite.name);
                    }
                }
                else if (fixedX == 10.331f)
                {
                    if (mixBox3.GetComponent<SpriteRenderer>().sprite == null)
                    {
                        mixBox3.GetComponent<SpriteRenderer>().sprite = Resources.Load(unitName, typeof(Sprite)) as Sprite;
                        MainController.Instance.UnitCount[mixBox3.GetComponent<SpriteRenderer>().sprite.name]--;
                        MainController.Instance.PaletteCountRefresh(mixBox3.GetComponent<SpriteRenderer>().sprite.name);
                    }
                }
            }

            nameText.text = "";

            Destroy(gameObject);
          
        }
    }




}
