using System;
using Player;
using TMPro;
using UnityEngine;
using Vehicle;

namespace UI
{
    public class PlayerHUD : MonoBehaviour
    {
        public static PlayerHUD i;
        
        
        public HealthBar playerHealthBar;
        public HealthBar roverHealthBar;
        public GameObject roverHUD;
        public TextMeshProUGUI currencyText;
        public int currencyCount;

        private void Awake()
        {
            i = this;
        }

        private void Start()
        {
            playerHealthBar.SetupUI(PlayerStats.i.maxHealth, PlayerStats.i.currentHealth);
        }

        public void SetupRoverUI(RoverStats roverStats)
        {
            roverHealthBar.SetupUI(roverStats.maxHealth, roverStats.currentHealth);
            roverHUD.gameObject.SetActive(true);
        }

        public void DisableRoverUI()
        {
            roverHUD.gameObject.SetActive(false);
        }
        
        public void UpdateCredits()
        {
            currencyCount++;
            currencyText.text = currencyCount.ToString();
        }
    }
}