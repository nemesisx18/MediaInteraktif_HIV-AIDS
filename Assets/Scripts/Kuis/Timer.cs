using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 300;
    public float localTimer;

    public bool timerIsRunning = false;

    public TextMeshProUGUI timeText;

    public delegate void OnTimeOut();
    public static OnTimeOut OnGameOver;

    private void OnEnable()
    {
        timerIsRunning = true;
    }

    private void OnDisable()
    {
    }

    void Update()
    {
        RunTimer();
    }

    public void StopTimer(int score)
    {
        timerIsRunning = false;
    }

    public void RunTimer()
    {
        localTimer = timeRemaining;

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                OnGameOver?.Invoke();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
