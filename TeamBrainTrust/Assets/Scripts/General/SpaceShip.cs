﻿using System;
using System.Collections;
using Quest;
using Systems.General;
using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace General
{
    public class SpaceShip : MonoBehaviour
    {

        [System.NonSerialized] public UnityEvent OnTakeOff = new UnityEvent();
        public ParticleSystem takeOffEffect;
        private bool takeOff;
        private float speed = 50;
        private float acceleration = 350;
        public Image blackScreen;
        private float alpha = 0;

        private void Start()
        {
            QuestManager.i.OnSpaceShipRepaired.AddListener(OnSpaceShipRepaired);
        }

        private void Update()
        {
            if (takeOff)
            {
                // transform.Translate(new Vector3(0, speed * Time.deltaTime));
                speed += acceleration * Time.deltaTime;
                alpha += 0.12f * Time.deltaTime;
                blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, alpha);

                SoundManager.SetVolume("Spaceship Takeoff", 1 - alpha);
            }
        }

        private void FixedUpdate()
        {
            if (takeOff)
            {
                // transform.Translate(new Vector3(0, speed * Time.deltaTime));
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, speed);
                // alpha += 0.1f * Time.deltaTime;
                blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, alpha);
            }
            
        }

        private void OnSpaceShipRepaired()
        {
            Interactable interactable = gameObject.AddComponent<Interactable>();
            interactable.onInteraction.AddListener(OnInteract);
        }

        private void OnInteract(GameObject player)
        {
            StartCoroutine("TakeOff");
            
            player.gameObject.SetActive(false);
            FindFirstObjectByType<CameraFollower>().SetTarget(gameObject, 15);
            PlayerHUD.i.gameObject.SetActive(false);
            ObjectiveHUD.i.gameObject.SetActive(false);
        }


        private IEnumerator TakeOff()
        {
            OnTakeOff.Invoke();
            
            SoundManager.PlaySound("Spaceship Takeoff");
            takeOffEffect.Play();
            GetComponent<EdgeCollider2D>().enabled = false;
            takeOff = true;
            
            
            yield return new WaitForSeconds(9);
            
            SceneManager.LoadScene("Win Scene");
        }
    }
}