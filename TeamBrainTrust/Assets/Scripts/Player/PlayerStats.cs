using System;
using UnityEngine;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        [HideInInspector]public int currentHealth;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        [ContextMenu("Take Damage")]
        public void TestTakeDamage()
        {
            TakeDamage(1);
        }
        
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if(currentHealth <= 0)
            {
                Death();
            }
        }

        private void Death()
        {
            gameObject.SetActive(false);
        }
    }
}