using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingCollider : MonoBehaviour
{
    public int index;
    public GameController gameController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            gameController.CeilingColliderStack(index);
            Debug.Log(index);
        }
    }

}
