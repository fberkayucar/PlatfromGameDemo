using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawBerry : MonoBehaviour
{
    public void Interact()
    {
        Destroy(gameObject);
        Debug.Log("Throwable collected!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interact();
    }
}
