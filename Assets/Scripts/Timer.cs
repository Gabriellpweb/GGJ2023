using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int bonusCoinsPerTime = 1;
    public float timeRemaining = 300;
    public float currencyTimeInterval = 10;
    
    private int coins = 0;
    private float lastTimeCurrencyGained= 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
       
            
            if (Time.time - lastTimeCurrencyGained > currencyTimeInterval)
            {
                lastTimeCurrencyGained = Time.time;
                coins += bonusCoinsPerTime;
                Debug.Log("Coins:" + coins);
            }

        }
    }
}
