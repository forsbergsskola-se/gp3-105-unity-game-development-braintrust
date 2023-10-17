using System;
using General;
using UnityEngine;


namespace Vehicle
{
    public class RoverPilot : MonoBehaviour
    {
        public bool isPlayerInRover;

        private void Start()
        {
            GetComponent<Interactable>().onInteraction.AddListener(OnPlayerInteraction);
        }

        public void OnPlayerInteraction(GameObject player)
        {
            Destroy(player);
            isPlayerInRover = true;
        }
    }
}