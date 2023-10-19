using System;
using General;
using Player;
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
            GetComponent<Interactable>().onInteraction.AddListener(OnPlayerInteraction);
        }

        private void Update()
        {
            if (isPlayerInRover && Input.GetButtonDown("Interact"))
            {
                ExitRover();
            }
        }

        public void OnPlayerInteraction(GameObject player)
        {
            player.GetComponent<PlayerStats>().rover = this;
            FindFirstObjectByType<CameraFollower>().SetTarget(gameObject);
            player.SetActive(false);
            isPlayerInRover = true;
            this.player = player;
        }

        private void ExitRover()
        {
            player.GetComponent<PlayerStats>().rover = null;
            FindFirstObjectByType<CameraFollower>().SetTarget(player.gameObject);
            isPlayerInRover = false;
            player.SetActive(true);
            player.transform.position = transform.position + new Vector3(1, 0, 0);
        }
    }
}