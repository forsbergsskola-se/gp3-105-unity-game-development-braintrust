using System;
using TMPro;
using UI;
using UnityEngine;

namespace Items
{
    public class Credit : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                PlayerHUD.i.UpdateCredits();
                Destroy(gameObject);
            }
        }
    }
}