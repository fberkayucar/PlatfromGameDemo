using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawBerry : MonoBehaviour
{
    public void Interact()
    {
        GlobalVariables.isBerryCollected = true;
        Destroy(gameObject);
        Debug.Log("Berry Collected");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interact();
    }
}
