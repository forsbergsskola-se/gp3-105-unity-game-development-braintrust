using System;
using Quest;
using UnityEngine;
using Vehicle;

namespace Compounds
{
    public class ParkingSpace : MonoBehaviour
    {
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Rover"))
            {
                QuestManager.i.OnEnterCompound();
                other.gameObject.GetComponent<RoverMovement>().currentSpeed = 0;
                gameObject.SetActive(false);
            }
        }
    }
}