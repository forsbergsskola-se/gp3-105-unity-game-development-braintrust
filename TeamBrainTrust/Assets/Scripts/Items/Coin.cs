using System;
using TMPro;
using UI;
using UnityEngine;

namespace Items
{
    public class Coin : MonoBehaviour
    {
        public int currencyCount;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            currencyCount++;
            Destroy(gameObject);
            GetComponent<PlayerHUD>().UpdateCurrency(currencyCount);
        }
    }
}