using UnityEngine;
using UnityEngine.Events;

namespace General
{
    public class Stats : MonoBehaviour
    {
        [System.NonSerialized] public UnityEvent OnDeath = new UnityEvent();
        
        public int maxHealth;
        [HideInInspector]public int currentHealth;

        public virtual void Awake()
        {
            currentHealth = maxHealth;
        }

        public virtual void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if(currentHealth <= 0)
            {
                Death();
            }
        }

        public virtual void Death()
        {
            OnDeath.Invoke();
        }
    }
}