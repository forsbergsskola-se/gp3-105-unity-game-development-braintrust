using System;
using UnityEngine;
using UnityEngine.Events;

namespace General
{
    public class Interactable : MonoBehaviour
    {
        private bool isPlayerInReach;
        private GameObject player;
        public UnityEvent<GameObject> onInteraction = new UnityEvent<GameObject>();

        private void Update()
        {   Debug.Log(isPlayerInReach);
            if (player == null)
            {
                isPlayerInReach = false;
            }
            
            if (isPlayerInReach && Input.GetButtonDown("Interact"))
            {
                onInteraction.Invoke(player);
                
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer==LayerMask.NameToLayer("Player"))
            {
                isPlayerInReach = true;
                player = other.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer==LayerMask.NameToLayer("Player"))
            {
                isPlayerInReach = false;
                player.SetActive(true);
            }
        }
    }
}