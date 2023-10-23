using System;
using UnityEngine;

namespace Items
{
    public class Coin : MonoBehaviour
    {
        private void Start()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
            
        }
    }
}