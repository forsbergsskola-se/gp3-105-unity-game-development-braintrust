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
        public ParticleSystem lightSmoke;
        public ParticleSystem heavySmoke;
        public ParticleSystem fire;
        public GameObject roverDestroyedPrefab;

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            
            GameObject player = GetComponent<RoverPilot>().player;
            
            if(player != null)
                PlayerHUD.i.roverHealthBar.UpdateUI(currentHealth);
            
            DisplaySmoke();
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


        void DisplaySmoke()
        {
            
            float healthPercentage = (float)currentHealth / (float)maxHealth;
            Debug.Log(healthPercentage);
            
            if (healthPercentage > 0.30f && healthPercentage <= 0.65f)
            {
                lightSmoke.Play();
            }
            else if (healthPercentage <= 0.30f)
            {
                lightSmoke.Stop();
                heavySmoke.Play();
                
            }

            if (healthPercentage <= 0.15f)
            {
                fire.Play();
            }
            
            
            
        }
    }
}