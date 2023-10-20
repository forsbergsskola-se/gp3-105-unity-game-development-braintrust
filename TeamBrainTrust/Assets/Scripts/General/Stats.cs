using UnityEngine;

namespace General
{
    public class Stats : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        [HideInInspector]public int currentHealth;

        public virtual void Start()
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
            
        }
    }
}