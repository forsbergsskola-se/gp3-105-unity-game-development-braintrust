using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Systems.General;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SoundManager.PlaySound("Death Ambience");
        }

        private IEnumerator CountdownDelay()
        {
            yield return new WaitForSeconds(respawnCountdownDelay);
            
            StartCoroutine("RespawnCountdown");
        }
        
        private IEnumerator RespawnCountdown()
        {
            respawnText.gameObject.SetActive(true);

            while (respawnCountdown > 0)
            {
                respawnText.text = $"Respawning in {respawnCountdown}";
                yield return new WaitForSeconds(1);
                
                respawnCountdown--;
            }

            SceneManager.LoadScene("Mandels Scene");
        }
        
    }
}