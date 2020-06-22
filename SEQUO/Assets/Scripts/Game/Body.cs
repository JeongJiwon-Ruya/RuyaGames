using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    private float x;
    private float y;


    private void OnMouseDown()
    {
        CoordinateSystem.Instance.ExitProcess(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), gameObject.GetComponentInParent<ProjectileScript>().name);
    }

    private void OnMouseDrag()
    {
        {
            x = Input.mousePosition.x;
            y = Input.mousePosition.y;

            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 16));

        }


    }
    private void OnMouseUp()
    {
        {
            MainController.Instance.UnitCount[gameObject.GetComponentInParent<ProjectileScript>().name]++;
            MainController.Instance.PaletteCountRefresh(gameObject.GetComponentInParent<ProjectileScript>().name);

            float fixedX = 0f;
            float fixedY = 0f;
            bool xInRange = true;
            /*
            bool yInRange = true;
            bool xForMix = false;
            bool yForMix = false;
            */
            if (1331 <= x && x < 1476)
                fixedX = 2.4f;
            else if (1476 <= x && x < 1633)
                fixedX = 3.9f;
            else if (1633 <= x && x < 1784)
                fixedX = 5.4f;
            else if (1849 <= x && x < 1946)
            {
                fixedX = 7.572f;
                xInRange = false;
  //              xForMix = true;
            }
            else if (1983 <= x && x < 2088)
            {
                fixedX = 8.949f;
                xInRange = false;
  //              xForMix = true;
            }
            else if (2128 <= x && x < 2222)
            {
                fixedX = 10.331f;
                xInRange = false;
 //               xForMix = true;
            }
            else
            {
                Debug.Log("X값 오류");
                xInRange = false;
            }
            //
            if (0 <= y && y < 149)
                fixedY = -4.5f;
            else if (149 <= y && y < 300)
                fixedY = -3f;
            else if ((300 <= y && y < 450))
                fixedY = -1.5f;
            else if (450 <= y && y < 600)
                fixedY = 0f;
            else if (600 <= y && y <= 750)
                fixedY = 1.5f;
            else if ((359 <= y && y < 464))
            {
                fixedY = -1.356f;
                xInRange = false;
            }
            else
            {
                Debug.Log("Y값 오류");
//                yInRange = false;
            }

            if (!(xInRange))
            {
                Destroy(gameObject);
                return;
            }


            if (CoordinateSystem.Instance.EnterProcess(new Vector2(fixedX, fixedY), gameObject.GetComponentInParent<ProjectileScript>().name))
            {

                gameObject.transform.position = new Vector3(fixedX, fixedY, 0);
            }
            else
            {
                CoordinateSystem.Instance.ExitProcess(new Vector2(fixedX, fixedY), gameObject.GetComponentInParent<ProjectileScript>().name);
                Destroy(gameObject);

            }
        }
    }

}
