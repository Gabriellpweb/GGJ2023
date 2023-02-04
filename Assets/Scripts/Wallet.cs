using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] public int coins;
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
