using System;
using UnityEngine;
using UnityEngine.Events;

namespace General
{
    public class Interactable : MonoBehaviour
    {
        public bool isPlayerActive = true;
        private bool isPlayerInReach;
        public bool IsPlayerHoldingCrate;
        private GameObject player;
        public UnityEvent<GameObject> onInteraction = new UnityEvent<GameObject>();

        private void Update()
        {   
            if (!isPlayerActive)
            {
                isPlayerInReach = false;
            }
            
            if (isPlayerInReach && isPlayerActive && !IsPlayerHoldingCrate && Input.GetButtonDown("Interact"))
            {
                onInteraction.Invoke(player);
            }

            if (isPlayerInReach && IsPlayerHoldingCrate && Input.GetButtonDown("Interact"))
            {
                onInteraction.Invoke(player);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                isPlayerInReach = true;
                player = other.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                isPlayerInReach = false;
                isPlayerActive = true;
            }
        }
    }
}