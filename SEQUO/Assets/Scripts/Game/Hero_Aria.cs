using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Aria : Hero
{
    public GameObject ArrowGen;
    public int Arrow_Damage;

    public override void SkillActive()
    {
        base.SkillActive();

        SoundEffectController.Instance.AriaSkillSound();
        ArrowGen.GetComponent<Aria_ArrowGenerator>().SkillActive();
        StartCoroutine(SkillActive_Co());
        BecomeMovePossible();
    }

    public IEnumerator SkillActive_Co()
    {
        anim.SetBool("Skill", true);
        yield return new WaitForSeconds(7f);
        anim.SetBool("Skill", false);
    }
}
