using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour, IInteractable
{

    //�z�mlerle etkile�ime ge�me
    public void Interact()
    {
        Destroy(gameObject);
        GlobalVariables.cherryCount--;
        if (GlobalVariables.cherryCount == 0)
        {
            //�z�mler topland���nda level� tamamlar
            GlobalVariables.isLevelCompleted = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interact();
    }
}
