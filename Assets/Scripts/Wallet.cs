using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wallet : SingletonBehaviour<Wallet>
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] public int coins;
    [SerializeField] static  public int TowerCost = 25;
    [SerializeField] private Timer timerController;

    string defaultCoinText = "SEEDS: ";
    // Start is called before the first frame update
    void Start()
    {
        coins = 100;
        timerController.OnTime += AddBonusCoin;
    }

    private void AddBonusCoin(object sender, int coin)
    {
        Debug.Log(coin);
        AddCoin(coin);
    }

    public void AddCoin(int amount)
    {
        coins += amount;
    }

    public bool spendCoins(int cost)
    {
        if (coins >= cost)
        {
            coins -= cost;
            return true;
        }

        return false;
    }

    public int getCoins()
    {
        return coins;
    }

    // Update is called once per frame
    void Update()
    {
        if (text != null)
        {
            text.text = defaultCoinText + getCoins();
        }
    }
}
