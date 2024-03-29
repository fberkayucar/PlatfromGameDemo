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
        //Sahne deðiþtiðinde canvasin yok olmamasý için
        DontDestroyOnLoad(gameObject);
    }

    //Çilek sayýsýný güncelle ve ekrana yazdýr
    private void UpdateCherryCount()
    {
        cherryText.text = GlobalVariables.cherryCount.ToString();
    }

    //GameManager instance'ý çaðýrýyorum ve GameManager nesnesi oluþuyor.
    public void PlayButton()
    {
        GameManager.Instance.GameStart();
        Destroy(instructionsPanel);
    }

    //Oyun sonu ekraný
    private void EndGame()
    {
        if (GlobalVariables.isGameFinished)
        {
            endGamePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
