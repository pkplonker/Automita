using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///PlayerTurn - Handles player turn
/// </summary>
public class PlayerTurn : MonoBehaviour
{
    [SerializeField] private TurnUI turnUI;
    [SerializeField] private float hideSpeed = 0.3f;
    public void TriggerTurnEvent()=>turnUI.Show(this);

    private void Awake()=>turnUI.Hide(0);
    public void TurnLeft()
    {
        transform.Rotate(Vector3.up, -90f);
        turnUI.Hide(hideSpeed);
    }
    public void TurnRight()
    {
        transform.Rotate(Vector3.up, 90f); 
        turnUI.Hide(hideSpeed);
    }
    
}
