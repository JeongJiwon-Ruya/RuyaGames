using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    protected Animator anim;
    public GameObject Skill;

    private Vector2 currentPos;

    private float x, y;
    private bool dragged = false;

    private bool movePossible = true;


    void Start()
    {

        anim = GetComponent<Animator>();
        transform.position = new Vector3(5.4f, 2.3f, 0.05f);
    }

    public virtual void SkillActive()
    {
        movePossible = false;
    }

    public void BecomeMovePossible()
    {
        movePossible = true;
    }
    



    private void OnMouseDown()
    {
        if(movePossible)
        {
            currentPos = transform.position;
            float xStair = 0.8f;

            CoordinateSystem.Instance.ExitProcess(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - xStair), gameObject.name);
            dragged = true;
        }
 
    }
    private void OnMouseDrag()
    {
        if (movePossible)
        {
            x = Input.mousePosition.x;
            y = Input.mousePosition.y;

            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 16));

        }


    }
    private void OnMouseUp()
    {
        if (movePossible)
        {

            float fixedX = 0f;
            float fixedY = 0f;
            float stairZ = 0;
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
            else if (2128 <= x && x < 2222)
            {
                fixedX = 10.331f;
                xForMix = true;
                xInRange = false;
            }
            else
                xInRange = false;

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
                if (CoordinateSystem.Instance.EnterProcessForHero(new Vector2(fixedX, fixedY), gameObject.name))
                {
                    float xStair = 0.8f;
           
                    gameObject.transform.position = new Vector3(fixedX, fixedY + xStair, stairZ);
                }
                else
                {
                    transform.position = currentPos;

                }

            }

            if (!xInRange)
            {
                if (!yForMix)
                {

                    transform.position = currentPos;
                    return;
                }
            }

            if (!yInRange)
            {
                if (!xForMix)
                {

                    transform.position = currentPos;
                    return;
                }
            }

           

        }
        dragged = false;
    }

}
