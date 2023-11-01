using System;
using General;
using Items;
using Quest;
using Systems.General;
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
            creditCount = PlayerPrefs.GetInt("Credits", creditCount);
            currentHealth = PlayerPrefs.GetInt("PlayerHealth", currentHealth);
        }

        private void Start()
        {
            //FOR NOW
            PlayerPrefs.SetInt("PlayerHealth", maxHealth);
            QuestManager.i.OnQuestCompleted.AddListener(SaveStats);
        }

        private void SaveStats()
        {
            PlayerPrefs.SetInt("PlayerHealth", currentHealth);
            PlayerPrefs.SetInt("Credits", creditCount);
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            PlayerHUD.i.playerHealthBar.UpdateUI(currentHealth);
            SoundManager.PlaySound("Player Take Damage");
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
            creditCount /= 2;
            PlayerPrefs.SetInt("Credits", creditCount);
            Destroy(gameObject);
        }
    }
}