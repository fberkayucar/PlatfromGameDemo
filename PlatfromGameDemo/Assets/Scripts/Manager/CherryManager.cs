using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryManager : MonoBehaviour
{
    //Toplam kiraz say�s�n� belirler
    private void Start()
    {
        CherryCount();
    }
    void CherryCount()
    {
        GlobalVariables.cherryCount = transform.childCount;
    }
}
