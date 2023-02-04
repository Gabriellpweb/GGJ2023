using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] public int coins;
    [SerializeField] static  public int TowerCost = 25;

    string defaultCoinText = "Coins: ";
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        coins = 100;
    }

    public void AddCoin(int amount)
    {
        coins += amount;
    }

    public bool spendCoins(int cost)
    {
        if (coins < cost)
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
        text.text = defaultCoinText + getCoins();
    }
}
