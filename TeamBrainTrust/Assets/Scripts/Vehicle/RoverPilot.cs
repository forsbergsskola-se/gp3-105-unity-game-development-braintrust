﻿using System;
using System.Collections;
using General;
using Player;
using Systems.General;
using UI;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;


namespace Vehicle
{
    public class RoverPilot : MonoBehaviour
    {
        public bool isPlayerInRover;
        public GameObject player;

        private bool canExitRover;

        private void Start()
        {
            GetComponent<Interactable>().onInteraction.AddListener(EnterRover);
        }

        private void Update()
        {
            if (isPlayerInRover && Input.GetButtonDown("Interact") && canExitRover)
            {
                ExitRover();
            }
        }

        public void EnterRover(GameObject player)
        {
            if(PlayerStats.i.itemInHand != null)
                return;
            
            RoverMovement rm = GetComponent<RoverMovement>();
            SwitchController(rm.maxSpeed, player, gameObject);  //Switch from controlling the player to controlling the rover
            
            SoundManager.PlaySound("Rover Start");
            SoundManager.PlaySound("Rover Idle");
            
            PlayerHUD.i.SetupRoverUI(GetComponent<RoverStats>());
            
            this.player = player;
            PlayerStats.i.rover = this;
            PlayerStats.i.OnEnterRover.Invoke();

            StartCoroutine("CanExitRover");
        }

        public void ExitRover()
        {
            if(!isPlayerInRover)
                return;
            
            PlayerMovement pm = player.GetComponent<PlayerMovement>();
            SwitchController(pm.speed, player, player); //Switch from controlling the rover to controlling the player
            
            SoundManager.StopSound("Rover Idle");
            SoundManager.PlaySound("Rover Door");
            
            player.transform.position = transform.position + new Vector3(1, 0, 0);
            PlayerHUD.i.DisableRoverUI();
            
            player = null;
            canExitRover = false;
            PlayerStats.i.OnExitRover.Invoke();
        }

        public void SwitchController(float speed, GameObject player, GameObject controllerGameObject)
        {
            FindFirstObjectByType<CameraFollower>().SetTarget(controllerGameObject, speed);
            
            player.SetActive(!player.activeSelf);
            isPlayerInRover = !isPlayerInRover;
        }

        private IEnumerator CanExitRover()
        {
            yield return new WaitForSeconds(0.5f);

            canExitRover = true;
        }
    }
}