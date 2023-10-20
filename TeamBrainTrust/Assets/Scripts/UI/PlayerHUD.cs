using System;
using Player;
using UnityEngine;

namespace UI
{
    public class PlayerHUD : MonoBehaviour
    {
        public HealthBar playerHealthBar;
        public HealthBar roverHealthBar;
        public PlayerStats playerStats;

        private void Start()
        {
            playerHealthBar.SetupUI(playerStats.maxHealth, playerStats.currentHealth);
        }
    }
}