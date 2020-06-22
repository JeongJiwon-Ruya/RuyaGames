using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Hyacinth : Hero
{
    public override void SkillActive()
    {
        base.SkillActive();
        SoundEffectController.Instance.HyacinthSkillSound();
        StartCoroutine(SkillActive_Co());
        Skill.transform.position = new Vector3(1.1f, -0.65f, 1f);
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
