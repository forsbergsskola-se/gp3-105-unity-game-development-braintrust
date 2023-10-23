using System;
using Quest;
using UnityEngine;

namespace Compounds
{
    public class Compound : MonoBehaviour
    {
        public int crates;

        private void OnTriggerEnter2D(Collider2D other)
        {
            FindFirstObjectByType<QuestManager>().EnterCompound();
            
        }
        
    }
}