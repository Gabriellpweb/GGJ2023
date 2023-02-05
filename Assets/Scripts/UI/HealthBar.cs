using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    [SerializeField] private float maxHeath;
    [SerializeField] private float currentHealth;

    public void SetCurrentHealth(int amount)
    {
        currentHealth = amount;
        Refresh();
    }

    public void ConfigureHealth(float maxHp, float currentHp)
    {
        maxHeath = maxHp;
        currentHealth = currentHp;
        Refresh();
    }

    private void Refresh()
    {
        if (currentHealth > 0)
        {
            float fill = currentHealth / maxHeath;
            healthImage.fillAmount = fill;
            return;
        }
        healthImage.fillAmount = 0;
    }
}
