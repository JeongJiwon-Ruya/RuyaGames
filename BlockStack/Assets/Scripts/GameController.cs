using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Ceilings_Parent;
    public GameObject[] Ceiling;
    private bool[] CeilingTF;


    public GameObject Blocks;
    public GameObject[] Block;
    public GameObject[] Silhouette;
    public GameObject Buttons;
    public Button UPB;
    public Button DOWNB;

    public GameObject ActiveWhenNotGameOver;
    public GameObject GameOverPopup;

    public GameObject HeightMeasureInst;
    public Button AddButton;
    public Offer Offer_1;
    public Offer Offer_2;
    private int score;
    public Text Score_Text;
    public Text HighScore_Text;
    public Text OverScore_Text;
    public Text Coin_Text;

    private GameObject SetBlock;
    private GameObject SetSilhouette;
    private float SetX, SetZ;

//    public Material[] Skins;
    private int selectedSkins;
    public Material[] Themes;

    public GameObject Floor;
    public GameObject[] FloorSkin;

    private int cameraIndex;
    public GameObject[] Cameras;

    int highScore;
    private void Awake()
    {
        Screen.SetResolution(Screen.width, (Screen.width * 19) / 9, true);

    }

    private void Start()
    {
        Application.targetFrameRate = 60;

        Offer_1.gameObject.SetActive(true);
        Offer_2.gameObject.SetActive(true);

     //   PlayerPrefs.SetInt("COIN", 100);

        highScore = PlayerPrefs.GetInt("HIGHSCORE");

        Coin_Text.text = PlayerPrefs.GetInt("COIN").ToString();

        selectedSkins = PlayerPrefs.GetInt("SKIN");


        Floor.GetComponent<MeshRenderer>().material = FloorSkin[selectedSkins].GetComponent<MeshRenderer>().material;


        Buttons.SetActive(false);

        HighScore_Text.text = highScore.ToString();

        score = 0;

        CeilingTF = new bool[9];

        OfferRefresh();

  //      Ceilings_OnOff(false);

        AddButton.onClick.AddListener(AddButtonClick);
    }

    private void OfferRefresh()
    {
        //     Ceilings_OnOff(false);

        int coin_Rand = Random.Range(0, 10);

        int rand1 = Random.Range(0, Block.Length);
        if(coin_Rand.Equals(0))
            Offer_1.SetInfo(Block[rand1].name, rand1,true);
        else
            Offer_1.SetInfo(Block[rand1].name, rand1, false);

        int rand2 = rand1;
        while (rand2 == rand1)
            rand2 = Random.Range(0, Block.Length);
        if(coin_Rand.Equals(1))
            Offer_2.SetInfo(Block[rand2].name, rand2,true);
        else
            Offer_2.SetInfo(Block[rand2].name, rand2, false);
    }

    public void CeilingColliderStack(int index)
    {
        CeilingTF[index] = true;
    }
    private void SilhouetteMove(float x, float z)
    {

        SetSilhouette.transform.localPosition = new Vector3(x, 1.0f, z);
    }
    public void ReceiveOffer(int index, bool coin)
    {
        if (coin)
        {
            StartCoroutine(CoinTextPopup());
        }

        SetBlock = Block[index];

        SetSilhouette = GameObject.Instantiate(Silhouette[index]);
        SetSilhouette.name = "Silhouette_Clone";
        SetSilhouette.transform.SetParent(HeightMeasureInst.transform);
        SilhouetteMove(20.0f, 20.0f);

        Buttons.SetActive(true);
    }

    public void LeftRotButtonClick()
    {
        SetSilhouette.transform.rotation = Quaternion.Euler(0, SetSilhouette.transform.rotation.eulerAngles.y - 90, 0);
    }

    public void RightRotButtonClick()
    {
        SetSilhouette.transform.rotation = Quaternion.Euler(0, SetSilhouette.transform.rotation.eulerAngles.y + 90, 0);
    }

    public GameObject LRButton;
    public GameObject RRButton;
    public GameObject CoinObject;
    public SFX _SFX;
    

    IEnumerator CoinTextPopup()
    {
        _SFX.PlayCoinGetSound();
        CoinObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        PlayerPrefs.SetInt("COIN", PlayerPrefs.GetInt("COIN") + 1);
        Coin_Text.text = PlayerPrefs.GetInt("COIN").ToString();
        yield return new WaitForSeconds(0.8f);
        CoinObject.SetActive(false);

    }

    public void ReceiveCoordinate(float x, float z)
    {
        SetX = x;
        SetZ = z;

        SilhouetteMove(x, z);
    }
    public void AddButtonClick()
    {
        StartCoroutine(AddButtonCoroutine());
    }

    IEnumerator AddButtonCoroutine()
    {
        UPB.gameObject.SetActive(false);
        DOWNB.gameObject.SetActive(false);
        LButton.gameObject.SetActive(false);
        RButton.gameObject.SetActive(false);
        LRButton.gameObject.SetActive(false);
        RRButton.gameObject.SetActive(false);

        Destroy(GameObject.Find("Silhouette_Clone"));
        GameObject StackedBlock = GameObject.Instantiate(SetBlock) as GameObject;
        StackedBlock.transform.rotation = Quaternion.Euler(0, SetSilhouette.transform.rotation.eulerAngles.y, 0);

        MeshRenderer[] m = StackedBlock.GetComponentsInChildren<MeshRenderer>();

        int themes = 0;

        // skin종류 늘어날때 수정
        switch (selectedSkins)
        {
            case 0:
                themes = 0;
                break;
            case 1:
                themes += 10;
                break;
            case 2:
                themes += 20;
                break;
            case 3:
                themes += 30;
                break;
            case 4:
                themes += 40;
                break;
            default:
                break;
        }
        
        
        for (int i = 0; i < m.Length; i++)
        {
            m[i].material = Themes[m[i].gameObject.GetComponentInParent<BlockInfo>().blockInfo + themes];
        }

        StackedBlock.transform.SetParent(HeightMeasureInst.transform);
        StackedBlock.transform.localPosition = new Vector3(SetX, 6.0f, SetZ);
        yield return StartCoroutine(CeilingCalculate());

        StackedBlock.GetComponent<Rigidbody>().mass = 10;

        StackedBlock.transform.SetParent(Blocks.transform);

        UPB.gameObject.SetActive(true);
        DOWNB.gameObject.SetActive(true);
        LButton.gameObject.SetActive(true);
        RButton.gameObject.SetActive(true);
        LRButton.gameObject.SetActive(true);
        RRButton.gameObject.SetActive(true);
    }

    public void UP()
    {
        StartCoroutine(CamUpDown(1));
    }
    public void DOWN()
    {
        StartCoroutine(CamUpDown(0));
    }

    IEnumerator CamUpDown(int i)
    {
        var wait = new WaitForSeconds(Time.smoothDeltaTime);
        float tempY = Mathf.Round(HeightMeasureInst.transform.position.y);


        UPB.interactable = false;
        DOWNB.interactable = false;
        if (i == 1)
        {
            while (HeightMeasureInst.transform.position.y < tempY + 1)
            {
                HeightMeasureInst.transform.Translate(new Vector3(0.0f, Time.smoothDeltaTime * 4, 0.0f));
                yield return wait;
            }
        }
        else
        {
            while (HeightMeasureInst.transform.position.y > tempY - 1)
            {
                HeightMeasureInst.transform.Translate(new Vector3(0.0f, -Time.smoothDeltaTime * 4, 0.0f));
                yield return wait;
            }
        }

        HeightMeasureInst.transform.position = new Vector3(HeightMeasureInst.transform.position.x, Mathf.Round(HeightMeasureInst.transform.position.y), HeightMeasureInst.transform.position.z);

        UPB.interactable = true;
        DOWNB.interactable = true;
    }

    bool isHighScore = false;

    IEnumerator CeilingCalculate()
    {
        AddButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        AddButton.gameObject.SetActive(true);

    //    _SFX.PlayBlockStackSound();

        score++;
        Score_Text.text = score.ToString();
        

        if(score > highScore)
        {
            isHighScore = true;
            HighScore_Text.text = score.ToString();
        }

        Buttons.SetActive(false);
        OfferRefresh();
        Offer_1.gameObject.SetActive(true);
        Offer_2.gameObject.SetActive(true);
    }

    public void GameOverPopupShowing()
    {
        if (score > PlayerPrefs.GetInt("HIGHSCORE"))
            PlayerPrefs.SetInt("HIGHSCORE", score);

        OverScore_Text.text = score.ToString();

        StartCoroutine(CameraZoomOut());

        ActiveWhenNotGameOver.SetActive(false);
        GameOverPopup.SetActive(true);

    }

    IEnumerator CameraZoomOut()
    {
        var wait = new WaitForSeconds(Time.smoothDeltaTime);

        while(MoveCamera.GetComponent<Camera>().orthographicSize < 15)
        {
            MoveCamera.GetComponent<Camera>().orthographicSize += 0.05f;

    //        Floor.transform.localScale = new Vector3(Floor.transform.localScale.x + 0.045f, 1.0f, Floor.transform.localScale.z + 0.135f);

            yield return wait;
        }
    }

    public void GoToMainButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LeftButton()
    {

        
        if (cameraIndex.Equals(0))
        {
            StartCoroutine(CamMove(MoveCamera, Cameras[3],0,3));
            cameraIndex = 3;
        }
        else if (cameraIndex.Equals(1))
        {
            StartCoroutine(CamMove(MoveCamera, Cameras[0],1,0));
            cameraIndex = 0;
        }
        else if (cameraIndex.Equals(2))
        {
            StartCoroutine(CamMove(MoveCamera, Cameras[1],2,1));
            cameraIndex = 1;
        }
        else if (cameraIndex.Equals(3))
        {
            StartCoroutine(CamMove(MoveCamera, Cameras[2],3,2));
            cameraIndex = 2;
        }
        
    }
    public void RightButton()
    {


        if (cameraIndex.Equals(0))
        {
            StartCoroutine(CamMove(MoveCamera, Cameras[1],0,1));
            cameraIndex = 1;
        }
        else if (cameraIndex.Equals(1))
        {
            StartCoroutine(CamMove(MoveCamera, Cameras[2],1,2));
            cameraIndex = 2;
        }
        else if (cameraIndex.Equals(2))
        {
            StartCoroutine(CamMove(MoveCamera, Cameras[3],2,3));
            cameraIndex = 3;
        }
        else if (cameraIndex.Equals(3))
        {
            StartCoroutine(CamMove(MoveCamera, Cameras[0],3,0));
            cameraIndex = 0;
        }
        
    }

    public GameObject Planet;

    IEnumerator CamRotate(GameObject cam)
    {
        var wait = new WaitForSeconds(Time.smoothDeltaTime);

        while (cam.transform.position.x < 7)
        {
            cam.transform.RotateAround(Planet.transform.position, Vector3.down, 100 * Time.smoothDeltaTime);
            yield return wait;
        }

    }


    public GameObject MoveCamera;
    public Button LButton, RButton;

    IEnumerator CamMove(GameObject startCam, GameObject destCam, int start, int destination)
    {
        LButton.interactable = false;
        RButton.interactable = false;

        var wait = new WaitForSeconds(Time.smoothDeltaTime);
        
        float destX = destCam.transform.position.x;
        float destZ = destCam.transform.position.z;


        
        if (start.Equals(0) && destination.Equals(1))
        {
            while (startCam.transform.position.x < 7)
            {
                startCam.transform.RotateAround(Planet.transform.position, Vector3.down, 150 * Time.smoothDeltaTime);
                yield return wait;
            }

        }
        else if (start.Equals(1) && destination.Equals(0))
        {
            while (startCam.transform.position.x > -7)
            {
                startCam.transform.RotateAround(Planet.transform.position, Vector3.up, 150 * Time.smoothDeltaTime);
                yield return wait;
            }
        }

        else if (start.Equals(1) && destination.Equals(2))
        {
            while (startCam.transform.position.z < 7)
            {
                startCam.transform.RotateAround(Planet.transform.position, Vector3.down, 150 * Time.smoothDeltaTime);
                yield return wait;
            }
        }
        else if (start.Equals(2) && destination.Equals(1))
        {
            while (startCam.transform.position.z > -7)
            {
                startCam.transform.RotateAround(Planet.transform.position, Vector3.up, 150 * Time.smoothDeltaTime);
                yield return wait;
            }
        }

        else if (start.Equals(2) && destination.Equals(3)) //Back -> Left  -90
        {
            while (startCam.transform.position.x > -7)
            {
                startCam.transform.RotateAround(Planet.transform.position, Vector3.down, 150 * Time.smoothDeltaTime);
                yield return wait;
            }
        }
        else if (start.Equals(3) && destination.Equals(2)) //Back -> Left  -90
        {
            while (startCam.transform.position.x < 7)
            {
                startCam.transform.RotateAround(Planet.transform.position, Vector3.up, 150 * Time.smoothDeltaTime);
                yield return wait;
            }
        }

        else if (start.Equals(3) && destination.Equals(0)) //Back -> Left  -90
        {
            while (startCam.transform.position.z > -7)
            {
                startCam.transform.RotateAround(Planet.transform.position, Vector3.down, 150 * Time.smoothDeltaTime);
                yield return wait;
            }
        }
        else if (start.Equals(0) && destination.Equals(3)) //Back -> Left  -90
        {
            while (startCam.transform.position.z < 7)
            {
                startCam.transform.RotateAround(Planet.transform.position, Vector3.up, 150 * Time.smoothDeltaTime);
                yield return wait;
            }
        }


        startCam.transform.localPosition = new Vector3(destX, 11.5f, destZ);
        startCam.transform.rotation = destCam.transform.rotation;

        LButton.interactable = true;
        RButton.interactable = true;
    }



}
