using System;
using General;
using Player;
using Systems.General;
using UnityEngine;

namespace Items
{
    public class PickUpItem : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Interactable>().onInteraction.AddListener(Pickup);
        }

        private void Pickup(GameObject player)
        {
            if(player.GetComponent<PlayerStats>().itemInHand != null)
                return;
            
            SoundManager.PlaySound("Pick Up Crate");
            transform.parent = player.transform;
            transform.localPosition = new Vector3(0, -0.35f, 0);

            player.GetComponent<PlayerStats>().itemInHand = this;
        }
        
    }
}