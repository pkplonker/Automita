﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "Scores")]
public class Highscore : ScriptableObject
{
    public float time;
    public int gold;

    public int GetTotalScore()=> (int)time * (gold / 4);
    
}