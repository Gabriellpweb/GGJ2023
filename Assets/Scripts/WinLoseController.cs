using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLoseController : SingletonBehaviour<WinLoseController>
{
    [SerializeField] int flag;
    [SerializeField] GameObject win;
    [SerializeField] GameObject lose;

    void Start()
    {
        win.SetActive(false);
        lose.SetActive(false);
    }

    public void ShowWinText()
    {
        win.SetActive(true);
        lose.SetActive(false);
    }

    public void ShowLoseText()
    {
        lose.SetActive(true);
        win.SetActive(false);
    }
}
