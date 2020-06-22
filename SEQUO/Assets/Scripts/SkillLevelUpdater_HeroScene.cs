using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillLevelUpdater_HeroScene : MonoBehaviour
{
    public Text PassiveSkillLevel;
    public Text PassiveSkillInfo;
    public Text ActiveSkillLevel;
    public Text ActiveSkillInfo;

    public string heroName;
    public string[] passiveSkill;
    public string[] activeSkill;


    private void Start()
    {
        int star = PlayerPrefs.GetInt(heroName + "_STAR");

        PassiveSkillLevel.text = "LV." + star.ToString();
        ActiveSkillLevel.text = "LV." +star.ToString();
        switch (star)
        {
            case 0:
                PassiveSkillInfo.text = passiveSkill[0];
                ActiveSkillInfo.text = activeSkill[0];
                break;
            case 1:
                PassiveSkillInfo.text = passiveSkill[1];
                ActiveSkillInfo.text = activeSkill[1];
                break;
            case 2:
                PassiveSkillInfo.text = passiveSkill[2];
                ActiveSkillInfo.text = activeSkill[2];
                break;
            case 3:
                PassiveSkillInfo.text = passiveSkill[3];
                ActiveSkillInfo.text = activeSkill[3];
                break;
        }
    }

    
}
