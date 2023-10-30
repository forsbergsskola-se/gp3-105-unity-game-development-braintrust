using System;
using General;
using Player;
using UnityEngine;
using UnityEngine.Events;

namespace General
{
    public class Interactable : MonoBehaviour
    {
        public bool isPlayerActive = true;
        private bool isPlayerInReach;
        private GameObject player;
        public UnityEvent<GameObject> onInteraction = new UnityEvent<GameObject>();

        private void Update()
        {   
            if (!isPlayerActive)
            {
                isPlayerInReach = false;
            }
            
            if (isPlayerInReach && isPlayerActive && Input.GetButtonDown("Interact"))
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
                player.GetComponent<PlayerUI>().DisplayUI(true);
               
                
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                isPlayerInReach = false;
                isPlayerActive = true;
                player.GetComponent<PlayerUI>().DisplayUI(false);
                

                
            }
        }
        
        
    }
}