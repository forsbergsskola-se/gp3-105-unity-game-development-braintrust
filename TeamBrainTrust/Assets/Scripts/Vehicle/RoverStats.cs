﻿using General;
using Player;
using UnityEngine;
using UnityEngine.Serialization;
using UI;

namespace Vehicle
{
    public class RoverStats : Stats
    {
        [HideInInspector]public PlayerStats playerStats;
        
        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            FindFirstObjectByType<PlayerHUD>().roverHealthBar.UpdateUI(currentHealth);
        }
        
        public override void Death()
        {
            base.Death();
            
            playerStats.TakeDamage(1);
        }
    }
}