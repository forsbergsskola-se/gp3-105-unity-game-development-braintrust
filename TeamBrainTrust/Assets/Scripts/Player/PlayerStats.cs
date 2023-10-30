using System;
using General;
using Items;
using Quest;
using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Vehicle;

namespace Player
{
    public class PlayerStats : Stats
    {
        public static PlayerStats i;
        
        [HideInInspector] public UnityEvent OnEnterRover = new UnityEvent();
        [HideInInspector] public UnityEvent OnExitRover = new UnityEvent();

        [System.NonSerialized] public int creditCount;
        [System.NonSerialized] public PickUpItem itemInHand; //This is the item that is picked up in the PickUpItem script
        [System.NonSerialized] public RoverPilot rover; //The rover the player currently is driving

        public override void Awake()
        {
            base.Awake();
            i = this;
        }

        private void Start()
        {
            //FOR NOW
            PlayerPrefs.SetInt("PlayerHealth", maxHealth);

            currentHealth = PlayerPrefs.GetInt("PlayerHealth", currentHealth);
            PlayerHUD.i.playerHealthBar.UpdateUI(currentHealth);
            
            QuestManager.i.OnQuestCompleted.AddListener(SaveCurrentHealth);
        }

        private void SaveCurrentHealth()
        {
            PlayerPrefs.SetInt("PlayerHealth", currentHealth);
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            PlayerHUD.i.playerHealthBar.UpdateUI(currentHealth);
        }

        public void Heal(int healingPower)
        {
            currentHealth += healingPower;
            
            if (currentHealth > maxHealth)
                currentHealth = maxHealth;
            
            PlayerHUD.i.playerHealthBar.UpdateUI(currentHealth);

        }

        public override void Death()
        {
            base.Death();
        }
    }
}