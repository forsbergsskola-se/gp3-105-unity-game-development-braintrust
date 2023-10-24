﻿using System;
using Player;
using TMPro;
using UnityEngine;
using Vehicle;

namespace UI
{
    public class PlayerHUD : MonoBehaviour
    {
        public HealthBar playerHealthBar;
        public HealthBar roverHealthBar;
        public GameObject roverHUD;
        public PlayerStats playerStats;
        public TextMeshProUGUI currencyText;
        public int currencyCount;
        
        private void Start()
        {
            playerHealthBar.SetupUI(playerStats.maxHealth, playerStats.currentHealth);
        }

        public void SetupRoverUI(RoverStats roverStats)
        {
            roverHealthBar.SetupUI(roverStats.maxHealth, roverStats.currentHealth);
            roverHUD.gameObject.SetActive(true);
            Debug.Log(roverStats);
        }

        public void DisableRoverUI()
        {
            roverHUD.gameObject.SetActive(false);
        }
        
        public void UpdateCurrency()
        {
            currencyCount++;
            currencyText.text = currencyCount.ToString();
        }
    }
}