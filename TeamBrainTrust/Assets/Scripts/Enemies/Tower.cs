using System;
using UnityEngine;

namespace Enemies
{
    public class Tower : MonoBehaviour
    {
        public float range;
        public int damage;
        public float reloadTime;
        private float countdown;

        private void Update()
        {
            countdown = countdown - Time.deltaTime;
            if (countdown <= 0)
            {
                Shoot();
                countdown = reloadTime;

            }
        }

        private void Shoot()
        {
            
        }

    }
    
}