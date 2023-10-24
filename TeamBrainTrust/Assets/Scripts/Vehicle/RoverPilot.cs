using System;
using General;
using Player;
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

        private void Start()
        {
            GetComponent<Interactable>().onInteraction.AddListener(EnterRover);
        }

        private void Update()
        {
            if (isPlayerInRover && Input.GetButtonDown("Interact"))
            {
                Debug.Log("!");
                ExitRover();
            }
        }

        public void EnterRover(GameObject player)
        {
            if(player.GetComponent<PlayerStats>().itemInHand != null)
                return;
            
            RoverMovement rm = GetComponent<RoverMovement>();
            SwitchController(rm.maxSpeed, player, gameObject);  //Switch from controlling the player to controlling the rover

            FindFirstObjectByType<PlayerHUD>().SetupRoverUI(GetComponent<RoverStats>());
            
            this.player = player;
        }

        public void ExitRover()
        {
            if(!isPlayerInRover)
                return;
            
            PlayerMovement pm = player.GetComponent<PlayerMovement>();
            SwitchController(pm.speed, player, player); //Switch from controlling the rover to controlling the player
            
            player.transform.position = transform.position + new Vector3(1, 0, 0);
            FindFirstObjectByType<PlayerHUD>().DisableRoverUI();
            
            player = null;
        }

        public void SwitchController(float speed, GameObject player, GameObject controllerGameObject)
        {
            FindFirstObjectByType<CameraFollower>().SetTarget(controllerGameObject, speed);
            
            player.SetActive(!player.activeSelf);
            isPlayerInRover = !isPlayerInRover;
        }
    }
}