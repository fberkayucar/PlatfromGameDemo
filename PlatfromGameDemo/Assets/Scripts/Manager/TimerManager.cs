using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private float elapsedTime = 0f;
    private float totalElapsedTime = 0f;
    public string timeText;
    public string totalTimeText;

    void Update()
    {
        Timer();
        UpdateTimeText();
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Timer()
    {
        elapsedTime += Time.deltaTime;
        totalElapsedTime += Time.deltaTime;
    }

    //Zamaný güncelle ve ekrana yazdýr
    void UpdateTimeText()
    {
        int minutes = (int)(elapsedTime / 60f);
        int seconds = (int)(elapsedTime % 60f);

        timeText = string.Format("{0:00}:{1:00}", minutes, seconds);

        int totalMinutes = (int)(totalElapsedTime / 60f);
        int totalSeconds = (int)(totalElapsedTime % 60f);
        totalTimeText = string.Format("Total Time: {0:00}:{1:00}", totalMinutes, totalSeconds);
    }

    //Zamaný sýfýrla ve tekrar baþlat
    public void RestartTimer()
    {
        elapsedTime = 0f;
    }
}
