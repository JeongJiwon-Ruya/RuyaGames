using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Hyacinth : Skill
{
    float elapsedTime = 0f;
    float goToEnd = 0f;
    float updown = 0f;
    bool up = false;
    float countinuedTime;
    bool HealOn = false;

    private void Start()
    {
        switch (PlayerPrefs.GetInt("HYACINTH_STAR"))
        {
            case 0:
                countinuedTime = 3f;
                break;
            case 1:
                countinuedTime = 4f;
                break;
            case 2:
                countinuedTime = 5f;
                break;
            case 3:
                countinuedTime = 6f;
                break;

        }
    }

    private void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
        goToEnd += Time.deltaTime;
        updown += Time.deltaTime;
        if(elapsedTime > 0.2f)
        {
            HealOn = true;
            elapsedTime = 0f;
        }
        if(goToEnd > countinuedTime)
        {
            goToEnd = 0f;
            HealOn = false;
            GameObject.Find("HYACINTH(Clone)").GetComponent<Hero>().BecomeMovePossible();
            gameObject.SetActive(false);
        }
        if(updown > 0.5f)
        {
            if (up)
                up = false;
            else
                up = true;

            updown = 0f;
        }
        if(up)
            transform.Translate(new Vector3(0f, 0.03f, 0f));
        else
            transform.Translate(new Vector3(0f, -0.03f, 0f));


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("tree"))
        {

            if(collision.gameObject.GetComponent<Tree>().health < collision.gameObject.GetComponent<Tree>().fullHealth)
            {
                

                collision.gameObject.GetComponent<Tree>().health += 1;
                collision.gameObject.GetComponent<Tree>().Heal(1);

                HealOn = false;
            }

        }
    }

}
