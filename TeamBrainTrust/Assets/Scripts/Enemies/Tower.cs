using System;
using Unity.Mathematics;
using UnityEngine;

namespace Enemies
{
    public class Tower : MonoBehaviour
    {
        public GameObject projectilePrefab;
        public float range;
        public int damage;
        public float reloadTime;
        private float countdown;

        private void Update()
        {
            if(!IsTowerActive())
            {
                return;
            }
            
            countdown -= Time.deltaTime;
            
            if (countdown <= 0)
            {
                Shoot();
                countdown = reloadTime;

            }
        }

        private bool IsTowerActive()
        {
            //Check if Player is in range?
            
            //Check if player is on current Objective?
    
            return true;
        }

        private void Shoot()
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }

    }
    
}