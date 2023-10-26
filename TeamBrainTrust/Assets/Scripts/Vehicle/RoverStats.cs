using System;
using General;
using Player;
using UnityEngine;
using UnityEngine.Serialization;
using UI;

namespace Vehicle
{
    public class RoverStats : Stats
    {
        public int explosiveDamage;
        


        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            
            GameObject player = GetComponent<RoverPilot>().player;
            
            if(player != null)
                PlayerHUD.i.roverHealthBar.UpdateUI(currentHealth);
        }
        
        public override void Death()
        {
            base.Death();
            
            GameObject player = GetComponent<RoverPilot>().player;
            
            if(player == null)
                return;
            
            player.GetComponent<PlayerStats>().TakeDamage(explosiveDamage);
            GetComponent<RoverPilot>().ExitRover();
            
            
            Destroy(gameObject);
        }
    }
}