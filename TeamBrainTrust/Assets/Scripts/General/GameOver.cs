using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using TMPro;
using UnityEngine;

namespace General
{
    public class GameOver : MonoBehaviour
    {
        public int respawnCountdown;
        public int respawnCountdownDelay;
        public TextMeshProUGUI respawnText;
        
        private void Start()
        {
            PlayerStats.i.OnDeath.AddListener(BeginRespawnCountdown);
        }

        public void BeginRespawnCountdown()
        {
            StartCoroutine("CountdownDelay");
        }

        private IEnumerator CountdownDelay()
        {
            yield return new WaitForSeconds(respawnCountdownDelay);
            
            StartCoroutine("RespawnCountdown");
        }
        
        private IEnumerator RespawnCountdown()
        {
            while (respawnCountdown > 0)
            {
                respawnText.text = $"Respawning in {respawnCountdown}";
                    
                yield return new WaitForSeconds(1);
                
                respawnCountdown--;
            }
        }
        
    }
}