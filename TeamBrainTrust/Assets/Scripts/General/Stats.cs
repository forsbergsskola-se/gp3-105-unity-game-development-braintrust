using UnityEngine;

namespace General
{
    public class Stats : MonoBehaviour
    {
        public int maxHealth;
        [HideInInspector]public int currentHealth;

        public virtual void Awake()
        {
            currentHealth = maxHealth;
            Debug.Log(currentHealth);
            
        }
        [ContextMenu("testdamage")]
        public void testdamage()
        {
            TakeDamage(1);
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