using System;
using General;
using Player;
using Systems.General;
using UnityEngine;

namespace Items
{
    public class PickUpItem : MonoBehaviour
    {

        private bool isPickedUp;
        private void Start()
        {
            GetComponent<Interactable>().onInteraction.AddListener(Pickup);
        }

        private void Update()
        {
            if(!isPickedUp)
                return;

            int xInput = (int)Input.GetAxisRaw("Horizontal");
            int yInput = (int)Input.GetAxisRaw("Vertical");

            if (yInput > 0 && !Input.GetButton("Horizontal"))
            {
                GetComponent<SpriteRenderer>().sortingOrder = 8;
                transform.localPosition = new Vector3(0, 0.3f, 0);
            }
            else if (yInput < 0 && !Input.GetButton("Horizontal"))
            {
                GetComponent<SpriteRenderer>().sortingOrder = 11;
                transform.localPosition = new Vector3(0, -0.35f, 0);
            }
            
            if (xInput > 0 && !Input.GetButton("Vertical"))
            {
                GetComponent<SpriteRenderer>().sortingOrder = 8;
                transform.localPosition = new Vector3(0.40f, 0, 0);
            }
            else if (xInput < 0 && !Input.GetButton("Vertical"))
            {
                GetComponent<SpriteRenderer>().sortingOrder = 8;
                transform.localPosition = new Vector3(-0.40f, 0, 0);
            }
            
            
        }

        private void Pickup(GameObject player)
        {
            if(player.GetComponent<PlayerStats>().itemInHand != null)
                return;
            isPickedUp = true;
            
            SoundManager.PlaySound("Pick Up Crate");
            transform.parent = player.transform;
            transform.localPosition = new Vector3(0, -0.35f, 0);

            player.GetComponent<PlayerStats>().itemInHand = this;
        }
        
    }
}