using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    public float lastCheck;
    public int frequency;
    private string defaultText = "Enemies ";
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    int count()
    {
        return GameObject.FindGameObjectsWithTag(DamageableObject.getEnemyTag()).Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastCheck > frequency)
        {
            lastCheck = Time.time;
            text.text = defaultText + count();
        }
    }
}
