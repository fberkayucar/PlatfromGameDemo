using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour, IInteractable
{

    //Üzümlerle etkileþime geçme
    public void Interact()
    {
        Destroy(gameObject);
        GlobalVariables.cherryCount--;
        if (GlobalVariables.cherryCount == 0)
        {
            //Üzümler toplandýðýnda levelý tamamlar
            GlobalVariables.isLevelCompleted = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interact();
    }
}
