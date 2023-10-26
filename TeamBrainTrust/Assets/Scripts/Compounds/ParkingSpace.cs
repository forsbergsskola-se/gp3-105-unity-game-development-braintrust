using System;
using Quest;
using UnityEngine;

namespace Compounds
{
    public class ParkingSpace : MonoBehaviour
    {
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("Rover"))
                QuestManager.i.OnEnterCompound();
        }
    }
}