using System;
using Player;
using TMPro;
using UI;
using UnityEngine;
using Vehicle;

namespace Items
{
    public class Credit : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (IsCollectible(other.gameObject))
            {
                other.gameObject.GetComponent<PlayerStats>().creditCount++;
                PlayerHUD.i.UpdateCredits();
                
                Destroy(gameObject);
            }
        }


        bool IsCollectible(GameObject gameObject)
        {
            if (gameObject.layer == LayerMask.NameToLayer("Player"))
                return true;
            if (gameObject.layer == LayerMask.NameToLayer("Rover") &&
                gameObject.GetComponent<RoverPilot>().isPlayerInRover)
                return true;

            return false;
        }
    }
}