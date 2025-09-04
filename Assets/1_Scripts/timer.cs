using System;
using System.Threading.Tasks;
using _1_Scripts;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    
    public Slider sliderGuy;
    public float gameTime;
    private bool stopTimer;

    private bool isRunning;
    private ClickPickup s;
    private readonly float TIMER_TOTAL = 5f;
    private readonly float INTERVAL = 0.01f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stopTimer = false;
        sliderGuy.maxValue = gameTime;
        sliderGuy.value = gameTime;

        TimerEvents.TimerStart += StartTimer;
    }

    private void OnDisable()
    {
        TimerEvents.TimerStart -= StartTimer;
    }

    private async void StartTimer()
    {
        try
        {
            isRunning = true;
            await DecreaseValueOverTime(TIMER_TOTAL, INTERVAL);
            isRunning = false;
            TimerEvents.OnTimerEnds();
        }
        catch (Exception e)
        {
            // Game Crashes xd
            throw e; 
        }
    }

    private async Task DecreaseValueOverTime(float duration, float interval)
    {
        var elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            Debug.Log($"Timer: {elapsedTime:F1}s");
            sliderGuy.value = sliderGuy.maxValue - ((elapsedTime / duration) * 2);
            await Task.Delay(TimeSpan.FromSeconds(interval));
            elapsedTime += interval;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !isRunning)
        { 
            StartTimer();
        }
        //float time = gameTime - Time.time;
        
        //int minutes = Mathf.FloorToInt(time / 60);
        //int seconds = Mathf.FloorToInt(time - minutes * 60f);

        //if (time <= 0)
        //{
        //    stopTimer = true;
        //    sliderGuy.value = time;
        //    Debug.Log("TimerEvents: stopTimer");
        //    TimerEvents.OnTimerEnds();
        //}
        
        
    }
}
