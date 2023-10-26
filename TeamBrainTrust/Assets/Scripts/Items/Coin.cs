using System;
using TMPro;
using UI;
using UnityEngine;

namespace Items
{
    public class Coin : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            PlayerHUD.i.UpdateCurrency();
            Destroy(gameObject);
        }
    }
}