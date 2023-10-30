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
        public TextMeshProUGUI gameoverText;
        
        private void Start()
        {
            PlayerStats.i.OnDeath.AddListener(BeginRespawnCountdown);
        }

        public void BeginRespawnCountdown()
        {
            StartCoroutine("CountdownDelay");
            gameoverText.gameObject.SetActive(true);
        }

        private IEnumerator CountdownDelay()
        {
            yield return new WaitForSeconds(respawnCountdownDelay);
            
            StartCoroutine("RespawnCountdown");
        }
        
        private IEnumerator RespawnCountdown()
        {
            respawnText.gameObject.SetActive(true);
            respawnText.text = $"Respawning in {respawnCountdown}";

            while (respawnCountdown > 0)
            {
                yield return new WaitForSeconds(1);
                
                respawnCountdown--;
                respawnText.text = $"Respawning in {respawnCountdown}";
            }
        }
        
    }
}