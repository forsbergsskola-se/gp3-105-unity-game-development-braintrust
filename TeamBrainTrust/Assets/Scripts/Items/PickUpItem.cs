using System;
using General;
using UnityEngine;

namespace Items
{
    public class PickUpItem : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Interactable>().onInteraction.AddListener(Pickup);
        }

        private void Pickup(GameObject player)
        {
            transform.parent = player.transform;
            transform.localPosition = new Vector3(0, -0.35f, 0);
        }
    }
}