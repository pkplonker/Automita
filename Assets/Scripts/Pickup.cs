using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using StuartH;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private int amount;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("picked up");
        GoldTracker.Pickup(amount <= 0 ? 1 : amount);
        Destroy(gameObject);
    }
}
