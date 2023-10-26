using System;
using Items;
using Quest;
using UnityEngine;

namespace Compounds
{
    public class Compound : MonoBehaviour
    {
        public int crates;
        public Transform cratesTransform;
        public ParkingSpace parkingSpace;
        private bool isObjective;

        public PickUpItem[] items;
        
        public void SetIsObjective(bool isObjective)
        {
            this.isObjective = isObjective;
            parkingSpace.gameObject.SetActive(isObjective);

            foreach (Transform child in cratesTransform)
            {
                child.gameObject.SetActive(isObjective);
            }

        }
        

        private void OnTriggerEnter2D(Collider2D other)
        {
            FindFirstObjectByType<QuestManager>().OnEnterCompound();
            
        }
        
    }
}