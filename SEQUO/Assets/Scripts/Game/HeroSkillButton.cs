using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSkillButton : MonoBehaviour
{
    public Image CircleGage;
    public GameObject SkillLoaded;
    public GameObject SkillImage;
    public Sprite[] SkillImages_RELOADING;
    public Sprite[] SkillImages_LOADED;

    private string HERO_SELECTED;
    private void Start()
    {
        switch (PlayerPrefs.GetString("HERO_SELECTED", "HYACINTH"))
        {
            case "HEIFETZ":
                HERO_SELECTED = "HEIFETZ(Clone)";
                SkillImage.GetComponent<Image>().sprite = SkillImages_RELOADING[0];
                SkillLoaded.GetComponent<Image>().sprite = SkillImages_LOADED[0];
                coolTime = 40f;//30
                break;
            case "HYACINTH":
                HERO_SELECTED = "HYACINTH(Clone)";
                SkillImage.GetComponent<Image>().sprite = SkillImages_RELOADING[1];
                SkillLoaded.GetComponent<Image>().sprite = SkillImages_LOADED[1];
                coolTime = 180f;
                break;
            case "ARIA":
                HERO_SELECTED = "ARIA(Clone)";
                SkillImage.GetComponent<Image>().sprite = SkillImages_RELOADING[2];
                SkillLoaded.GetComponent<Image>().sprite = SkillImages_LOADED[2];
                coolTime = 120f;//240
                break;
        }

        coolTimeConstant = 1 / coolTime;
    }
    public void OnButtonClick()
    {
        if (skillActive)
        {
            GameObject.Find(HERO_SELECTED).GetComponent<Hero>().SkillActive();
            currentTime = 0f;
            CircleGage.fillAmount = 0f;
            SkillLoaded.SetActive(false);
            skillActive = false;
        }
    }



    float coolTime = 5f;
    float currentTime = 0f;
    bool skillActive = false;
    float coolTimeConstant;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(currentTime < coolTime)
        {
            currentTime += Time.deltaTime;
            CircleGage.fillAmount += coolTimeConstant * Time.deltaTime;
        }
        if (currentTime >= coolTime)
        {
            skillActive = true;
            SkillLoaded.SetActive(true);
        }
    }
}
