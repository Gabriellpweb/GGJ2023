using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public int bonusCoinsPerTime = 1;
    public float remainingTime = 300;
    public TextMeshProUGUI timeText;
    public float currencyTimeInterval = 10;
   
    private int coins = 0;
    private float lastTimeCurrencyGained= 0;
    
    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
       
            
            if (Time.time - lastTimeCurrencyGained > currencyTimeInterval)
            {
                lastTimeCurrencyGained = Time.time;
                coins += bonusCoinsPerTime;
                
            }

        }
        DisplayTime(remainingTime);
    }

    void DisplayTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
