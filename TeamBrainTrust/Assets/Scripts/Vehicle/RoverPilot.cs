using System;
using General;
using Player;
using UI;
using Unity.Mathematics;
using UnityEngine;


namespace Vehicle
{
    public class RoverPilot : MonoBehaviour
    {
        public bool isPlayerInRover;
        private GameObject player;

        private void Start()
        {
            GetComponent<Interactable>().onInteraction.AddListener(EnterRover);
        }

        private void Update()
        {
            if (isPlayerInRover && Input.GetButtonDown("Interact"))
            {
                ExitRover();
            }
        }

        public void EnterRover(GameObject player)
        {
            RoverMovement rm = GetComponent<RoverMovement>();
            player.GetComponent<PlayerStats>().rover = this;
            GetComponent<RoverStats>().playerStats = player.GetComponent<PlayerStats>();
            
            FindFirstObjectByType<CameraFollower>().SetTarget(gameObject, rm.maxSpeed);
            player.SetActive(false);
            isPlayerInRover = true;
            this.player = player;
            FindFirstObjectByType<PlayerHUD>().SetupRoverUI(GetComponent<RoverStats>());
        }

        public void ExitRover()
        {
            PlayerMovement pm = player.GetComponent<PlayerMovement>();
            player.GetComponent<PlayerStats>().rover = null;
            FindFirstObjectByType<CameraFollower>().SetTarget(player.gameObject, pm.speed);
            isPlayerInRover = false;
            player.SetActive(true);
            player.transform.position = transform.position + new Vector3(1, 0, 0);
            FindFirstObjectByType<PlayerHUD>().DisableRoverUI();
        }
    }
}