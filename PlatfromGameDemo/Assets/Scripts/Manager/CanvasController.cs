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

    private float elapsedTime = 0f;
    private float totalElapsedTime = 0f; 
    private bool counterActive = false;

    private void Update()
    {
        EndGame();
        UpdateCherryCount();
        Timer();
        UpdateTimeText();
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

    private void Timer()
    {
        if (counterActive)
        {
            elapsedTime += Time.deltaTime;
            totalElapsedTime += Time.deltaTime;
        }
    }

    //Zaman� g�ncelle ve ekrana yazd�r
    void UpdateTimeText()
    {
        int minutes = (int)(elapsedTime / 60f);
        int seconds = (int)(elapsedTime % 60f);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        int totalMinutes = (int)(totalElapsedTime / 60f);
        int totalSeconds = (int)(totalElapsedTime % 60f);
        totalTimeText.text = string.Format("Total Time: {0:00}:{1:00}", totalMinutes, totalSeconds);
    }

    //Level tamamland���nda zaman� durdur ve ekrana yazd�r
    public void LevelCompleted()
    {
        counterActive = false;
        elapsedTime = 0f;
        UpdateTimeText();
    }

    //Zaman� s�f�rla ve tekrar ba�lat
    public void RestartTimer()
    {
        counterActive = true;
        elapsedTime = 0f;
    }

    //GameManager instance'� �a��r�yorum ve GameManager nesnesi olu�uyor.
    public void PlayButton()
    {
        counterActive = true;
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
            counterActive = false;
        }
    }
}
