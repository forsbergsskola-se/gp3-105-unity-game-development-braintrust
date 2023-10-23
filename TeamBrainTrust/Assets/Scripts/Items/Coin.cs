using System;
using TMPro;
using UI;
using UnityEngine;

namespace Items
{
    public class Coin : MonoBehaviour
    {
        public int currency;
        
        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
            currency++;
            GetComponent<PlayerHUD>().UpdateCurrency(currency);
        }
    }
}