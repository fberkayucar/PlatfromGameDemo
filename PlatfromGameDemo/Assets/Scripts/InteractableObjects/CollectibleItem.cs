using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Destroy(gameObject);
        Collect();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interact();
    }

    private void Collect()
    {
        Debug.Log("Item collected!");
    }
}
