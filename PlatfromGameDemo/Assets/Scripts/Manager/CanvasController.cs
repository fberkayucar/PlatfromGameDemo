using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public TextMeshProUGUI cherryText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI totalTimeText;
    public CherryManager cherryManager;
    public GameObject instructionsPanel;
    public GameObject endGamePanel;
    public TimerManager timerManager;

    public void Destroy()
    {
        Destroy(gameObject);
    }


    private void Update()
    {
        totalTimeText.text = timerManager.totalTimeText;
        timeText.text = timerManager.timeText;
        EndGame();
        UpdateCherryCount();
    }

    private void Start()
    {
        //Sahne de�i�ti�inde canvasin yok olmamas� i�in
        DontDestroyOnLoad(gameObject);
    }

    //�ilek say�s�n� g�ncelle ve ekrana yazd�r
    private void UpdateCherryCount()
    {
        cherryText.text = GlobalVariables.cherryCount.ToString();
    }

    //GameManager instance'� �a��r�yorum ve GameManager nesnesi olu�uyor.
    public void PlayButton()
    {
        GameManager.Instance.GameStart();
        Destroy(instructionsPanel);
    }

    //Oyun sonu ekran�
    private void EndGame()
    {
        if (GlobalVariables.isGameFinished)
        {
            endGamePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
