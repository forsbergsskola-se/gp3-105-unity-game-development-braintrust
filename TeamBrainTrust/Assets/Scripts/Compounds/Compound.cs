using System;
using Quest;
using UnityEngine;

namespace Compounds
{
    public class Compound : MonoBehaviour
    {
        public int crates;

        private void OnTriggerEnter(Collider other)
        {
            FindFirstObjectByType<QuestManager>().EnterCompound();
        }
    }
}