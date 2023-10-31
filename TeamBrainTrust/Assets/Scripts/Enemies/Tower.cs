using System;
using Player;
using Unity.Mathematics;
using UnityEngine;

namespace Enemies
{
    public class Tower : MonoBehaviour
    {
        public GameObject projectilePrefab;
        public float reloadTime;
        private float countdown;
        private bool isPlayerInRange = false;
        public Transform canonTransform;
        private GameObject target;
        public float rotationDamping;

        private void Start()
        {
            SetTargetToPlayer();
            PlayerStats.i.OnEnterRover.AddListener(SetTargetToRover);
            PlayerStats.i.OnExitRover.AddListener(SetTargetToPlayer);

        }

        private void SetTargetToPlayer()
        {
            target = PlayerStats.i.gameObject;
        }
        private void SetTargetToRover()
        {
            target = PlayerStats.i.rover.gameObject;
        }

        private void Update()
        {
            if(!IsTowerActive())
            {
                return;
            }

            RotateTowardsTarget();
            
            countdown -= Time.deltaTime;
            
            if (countdown <= 0)
            {
                Shoot();
                countdown = reloadTime;

            }
        }

        private void RotateTowardsTarget()
        {
            Vector3 targetLookPos = Quaternion.Euler(0, 0, 180) * (target.transform.position - transform.position);
            Quaternion rotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: targetLookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping); 
        }

        private bool IsTowerActive()
        {
            if (!isPlayerInRange)
            {
                return false;
            }
    
            return true;
        }

        private void Shoot()
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }

        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("Rover"))
            {
                isPlayerInRange = true;
                target = other.gameObject;
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("Rover"))
            {
                isPlayerInRange = false;
            }
        }
        
    }
    
}