using System;
using General;
using Items;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using Vehicle;

namespace Player
{
    public class PlayerStats : Stats
    {
        public PickUpItem itemInHand; //This is the item that is picked up in the PickUpItem script
        public RoverPilot rover; //The rover the player currently is driving
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