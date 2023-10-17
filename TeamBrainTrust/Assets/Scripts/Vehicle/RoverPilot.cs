using System;
using General;
using UnityEngine;


namespace Vehicle
{
    public class RoverPilot : MonoBehaviour
    {
        private bool isPlayerInRover;

        private void Start()
        {
            GetComponent<Interactable>().onInteraction.AddListener(OnPlayerInteraction);
        }

        private void OnPlayerInteraction()
        {
            
        }
    }
}