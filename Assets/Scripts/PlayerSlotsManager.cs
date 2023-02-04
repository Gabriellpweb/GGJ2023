using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlotsManager : SingletonBehaviour<PlayerSlotsManager>
{
    private PlayerUnitSlot[] playerSlots;

    void Start()
    {
        playerSlots = FindObjectsByType<PlayerUnitSlot>(FindObjectsSortMode.None);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
