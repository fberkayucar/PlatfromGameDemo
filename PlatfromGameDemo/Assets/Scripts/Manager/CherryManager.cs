using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryManager : MonoBehaviour
{
    private void Start()
    {
        CherryCount();
    }
    void CherryCount()
    {
        GlobalVariables.cherryCount = transform.childCount;
    }
}
