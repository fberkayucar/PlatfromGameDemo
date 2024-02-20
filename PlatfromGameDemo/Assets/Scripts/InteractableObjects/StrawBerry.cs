using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawBerry : MonoBehaviour
{
    PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    public void Interact()
    {
        Destroy(gameObject);
        playerController.isBerryCollected = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interact();
    }
}
