using System;
using System.Collections;
using Quest;
using Systems.General;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace General
{
    public class SpaceShip : MonoBehaviour
    {
        public ParticleSystem takeOffEffect;
        private bool takeOff;
        private float speed = 1;
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
                speed += Time.deltaTime;
                alpha += 0.12f * Time.deltaTime;
                blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, alpha);
            }
        }

        private void FixedUpdate()
        {
            if (takeOff)
            {
                // transform.Translate(new Vector3(0, speed * Time.deltaTime));
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 50 * speed * Time.deltaTime);
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
            FindFirstObjectByType<CameraFollower>().SetTarget(gameObject, 8);
        }


        private IEnumerator TakeOff()
        {
            SoundManager.PlaySound("Spaceship Takeoff");
            takeOffEffect.Play();
            GetComponent<EdgeCollider2D>().enabled = false;
            takeOff = true;
            
            
            yield return new WaitForSeconds(9);
            
            SceneManager.LoadScene("Win Scene");
        }
    }
}