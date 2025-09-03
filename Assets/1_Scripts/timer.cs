using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    
    public Slider sliderGuy;
    public float gameTime;
    private bool stopTimer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    stopTimer = false;
    sliderGuy.maxValue = gameTime;
    sliderGuy.value = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        float time = gameTime - Time.time;
        
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        if (time <= 0)
        {
            stopTimer = true;
        }

        if (stopTimer == false)
        {
         sliderGuy.value = time;   
        }
    }
}
