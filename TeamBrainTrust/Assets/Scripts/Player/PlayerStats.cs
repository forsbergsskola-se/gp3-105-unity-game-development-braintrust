﻿using System;
using General;
using Items;
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
        
        [FormerlySerializedAs("OnEnter")] [HideInInspector] public UnityEvent OnEnterRover = new UnityEvent();
        [FormerlySerializedAs("OnExit")] [HideInInspector] public UnityEvent OnExitRover = new UnityEvent();
        
        
        public PickUpItem itemInHand; //This is the item that is picked up in the PickUpItem script
        public RoverPilot rover; //The rover the player currently is driving

        public override void Awake()
        {
            base.Awake();
            i = this;
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