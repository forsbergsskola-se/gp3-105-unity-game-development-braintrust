using System;
using Player;
using UnityEngine;
using Vehicle;

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

        public void SetupRoverUI(RoverStats roverStats)
        {
            roverHealthBar.SetupUI(roverStats.maxHealth, roverStats.currentHealth);
        }
    }
}