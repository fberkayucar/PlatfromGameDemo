using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Destroy(gameObject);
        Debug.Log("Item collected!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interact();
    }
}
