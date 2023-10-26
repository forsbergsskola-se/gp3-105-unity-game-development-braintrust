using System;
using Quest;
using UnityEngine;

namespace Compounds
{
    public class ParkingSpace : MonoBehaviour
    {
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(LayerMask.LayerToName(other.gameObject.layer));
            
            if(other.gameObject.layer == LayerMask.NameToLayer("Rover"))
                QuestManager.i.OnEnterCompound();
        }
    }
}