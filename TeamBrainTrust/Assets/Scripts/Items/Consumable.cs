using System;
using Player;
using UnityEngine;

namespace Items
{
    public class Consumable : MonoBehaviour
    {
        public int healPower;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                other.gameObject.GetComponent<PlayerStats>().Heal(healPower);
                Destroy(gameObject);
            }
        }
    }
}