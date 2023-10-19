using System;
using General;
using Player;
using Unity.Mathematics;
using UnityEngine;


namespace Vehicle
{
    public class RoverPilot : MonoBehaviour
    {
        private bool isPlayerInRover;
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
            player.SetActive(false);
            isPlayerInRover = true;
            this.player = player;
        }

        private void ExitRover()
        {
            player.GetComponent<PlayerStats>().rover = null;
            isPlayerInRover = false;
            player.SetActive(true);
            player.transform.position = transform.position + new Vector3(1, 0, 0);
        }
    }
}