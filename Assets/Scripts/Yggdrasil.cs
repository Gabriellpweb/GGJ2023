using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yggdrasil : DamageableObject
{

    private void Start()
    {
        OnDie += OnDieEvent;
    }

    public void OnDieEvent(object sender, System.EventArgs e)
    {
        WinLoseController.instance.ShowLoseText();
    }
}
