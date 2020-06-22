using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Heifetz : Hero
{
    
    public override void SkillActive()
    {
        base.SkillActive();

        SoundEffectController.Instance.HeifetzSkillSound();
        StartCoroutine(SkillActive_Co());
        Skill.transform.localPosition = new Vector3(-4f, -1f, 1f);
    }
    
    public IEnumerator SkillActive_Co()
    {
        anim.SetBool("Skill", true);
        yield return new WaitForSeconds(0.085f);
        anim.SetBool("Skill", false);
        yield return new WaitForSeconds(0.1f);
        Skill.SetActive(true);
    }

}
