using System;
using General;
using Unity.Mathematics;
using UnityEngine;


namespace Vehicle
{
    public class RoverPilot : MonoBehaviour
    {
        public bool isPlayerInRover;
        public GameObject player;

        private void Start()
        {
            GetComponent<Interactable>().onInteraction.AddListener(OnPlayerInteraction);
        }

        private void Update()
        {
            if (isPlayerInRover && Input.GetButtonDown("Interact"))
            {
                isPlayerInRover = false;
                player.SetActive(true);
                player.transform.position = transform.position + new Vector3(1, 0, 0);
            }
        }

        public void OnPlayerInteraction(GameObject player)
        {
            player.SetActive(false);
            isPlayerInRover = true;
            this.player = player;
        }
    }
}