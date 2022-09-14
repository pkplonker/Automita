using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuartH
{
    /// <summary>
    ///GoldTracker - DisplaysGold
    /// </summary>
    public class GoldTracker : MonoBehaviour
    {
        private static int totalAmount;
        public static event Action<int> OnPickup;
        [SerializeField] private Score score;

        private void OnDestroy()=>score.gold = totalAmount;
        

        public static void Pickup(int amount)
        {
            totalAmount += amount;
            OnPickup?.Invoke(totalAmount);
        }
    }
}