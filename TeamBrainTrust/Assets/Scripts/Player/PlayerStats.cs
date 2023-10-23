using System;
using General;
using UI;
using UnityEngine;
using Vehicle;

namespace Player
{
    public class PlayerStats : Stats
    {
        public bool questActive;
        public RoverPilot rover;
        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            FindFirstObjectByType<PlayerHUD>().playerHealthBar.UpdateUI(currentHealth);
        }

        public override void Death()
        {
            base.Death();
        }
    }
}