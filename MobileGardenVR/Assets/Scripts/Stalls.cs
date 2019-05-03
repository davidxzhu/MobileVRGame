﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(EventTrigger))]
public class Stalls : MonoBehaviour
{
    PlayerStats pStats;

    void Start() {
        gameObject.AddListener(EventTriggerType.PointerClick, sellInventory); 
    }

    public void sellInventory(){
        int apple = pStats.appleCount;
        int plant = pStats.plantCount;
        pStats.score = pStats.score + apple * 2 + plant * 3;
        pStats.appleCount = 0;
        pStats.plantCount = 0;
    }
    
}
