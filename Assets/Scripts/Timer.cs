using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class Timer : MonoBehaviour
{
    public delegate void GenericEventHandler(object sender, int e);
    public event GenericEventHandler OnTime;

    private TextMeshProUGUI text;
    public int bonusCoinsPerTime = 15;
    public float remainingTime = 300;
    public TextMeshProUGUI timeText;
    public float currencyTimeInterval = 10;
    private int[] secsWithDiffColor;
    private float lastTimeCurrencyGained = 0;
    public float minute;

    private void Awake()
    {
        minute = remainingTime / 60;
    }
    private void Start()
    {
        secsWithDiffColor = new int[] { 0, 1, 59, 58, 2 };
        text = GetComponent<TextMeshProUGUI>();
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
                Debug.Log(bonusCoinsPerTime);
                OnTime?.Invoke(this, bonusCoinsPerTime); 
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

        if (containInt((int)seconds))
        {
            text.color = Color.red;
        }

        minute = minutes;

    }

    bool containInt(int i) //ewww
    {
        foreach (int n in secsWithDiffColor)
        {
            if (i == n)
            {
                return true;
            }
        }

        return false;
    }
}
