using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAttack : MonoBehaviour
{
    private bool on;
    private Vector3 lockPos;

    public IEnumerator EffectOnOff(Vector3 motherPos)
    {
        lockPos = motherPos;
        on = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.2f);


        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.position = Vector3.zero;
        
        on = false;
 

        yield return null;
    }

    private void Update()
    {
        if (on)
        {
            gameObject.transform.position = lockPos;
        }
    }


}
