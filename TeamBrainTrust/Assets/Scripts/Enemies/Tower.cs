﻿using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Unity.Mathematics;
using UnityEngine;
using Vehicle;

namespace Enemies
{
    public class Tower : MonoBehaviour
    {
        public GameObject projectilePrefab;
        public Transform canonTransform;
        public float reloadTime;
        public float rotationDamping;

        public float rapidFireInterval;
        public int rapidFireAmount;
        
        
        private float countdown;
        private bool isPlayerInRange = false;
        private GameObject target;
        

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
                StartCoroutine("Shoot");
                countdown = reloadTime;

            }
        }

        private void RotateTowardsTarget()
        {
            Vector3 targetLookPos = Quaternion.Euler(0, 0, 180) * (target.transform.position - transform.position);
            Quaternion rotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: targetLookPos);
            canonTransform.rotation = Quaternion.Slerp(canonTransform.rotation, rotation, Time.deltaTime * rotationDamping); 
        }

        private bool IsTowerActive()
        {
            if (!isPlayerInRange)
            {
                return false;
            }
    
            return true;
        }

        private IEnumerator Shoot()
        {
            for (int i = 0; i < rapidFireAmount; i++)
            {
                Instantiate(projectilePrefab, canonTransform.position, canonTransform.rotation);
                yield return new WaitForSeconds(rapidFireInterval);
            }
        }

        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (IsTargetable(other.gameObject))
            {
                isPlayerInRange = true;
                target = other.gameObject;
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (IsTargetable(other.gameObject))
            {
                isPlayerInRange = false;
            }
        }
        
        
        bool IsTargetable(GameObject gameObject)
        {
            if (gameObject.layer == LayerMask.NameToLayer("Player"))
                return true;
            
            if (gameObject.layer == LayerMask.NameToLayer("Rover") &&
                gameObject.GetComponent<RoverPilot>().isPlayerInRover)
                return true;

            return false;
        }
        
    }
    
}