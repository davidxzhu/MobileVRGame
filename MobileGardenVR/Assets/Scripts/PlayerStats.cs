﻿using UnityEngine;

[CreateAssetMenu(menuName="player")]
public class PlayerStats : ScriptableObject
{
    public int appleCount;
    public int plantCount;
    public int score;
    
    public float water;
    public Tools currTool;
}
