using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Destroy(gameObject);
        Debug.Log("Item collected!");
        GlobalVariables.cherryCount--;
        Debug.Log("Cherry count: " + GlobalVariables.cherryCount);
        if (GlobalVariables.cherryCount == 0)
        {
            GlobalVariables.isLevelCompleted = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interact();
    }
}
