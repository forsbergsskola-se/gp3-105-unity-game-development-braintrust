using System;
using UnityEngine;
using UnityEngine.Events;

namespace General
{
    public class Interactable : MonoBehaviour
    {
        private bool isPlayerInReach;
        public UnityEvent onInteraction;

        private void Update()
        {
            if (isPlayerInReach && Input.GetButton("Interact"))
            {
                
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            isPlayerInReach = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            isPlayerInReach = false;
        }
    }
}