using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI text;
    public int bonusCoinsPerTime = 1;
    public float remainingTime = 300;
    public TextMeshProUGUI timeText;
    public float currencyTimeInterval = 10;
    private int[] secsWithDiffColor;
    private int coins = 0;
    private float lastTimeCurrencyGained = 0;
    public float minute;

    private void Start()
    {
        secsWithDiffColor = new int[] { 0, 1, 59, 58, 2 };
        text = GetComponent<TextMeshProUGUI>();
        minute = remainingTime / 60;
    }

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

        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        switch(minutes)
        {
            case 5:
            case 4:
                text.color = Color.green;
                break;
            case 3:
            case 2:
                text.color = Color.yellow;
            break;
            case 1:
                text.color = Color.red;
            break;
        }

        if (ArrayUtility.Contains<int>(secsWithDiffColor, ((int)seconds)))
        {
            text.color = Color.red;
        }

        minute = minutes;

    }
}
