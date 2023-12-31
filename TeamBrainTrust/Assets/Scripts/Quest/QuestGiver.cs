﻿using System.Collections;
using UnityEngine;
using General;
using Systems.General;
using Unity.Mathematics;
using Random = UnityEngine.Random;

namespace Quest
{
    public class QuestGiver : MonoBehaviour
    {
        public GameObject CreditPrefab;
        public ParticleSystem heartEffect;
        
        private void Start()
        {
            GetComponent<Interactable>().onInteraction.AddListener(Interact);
        }

        private void Interact(GameObject player)
        {
            QuestManager manager = GetComponent<QuestManager>();
            SoundManager.PlaySound("Beep Boop  ");
            
            if (manager.questActive)
            {
                if (manager.isObjectiveCompleted)
                {
                    CompleteQuest();
                    return;
                    
                }

                //Add popup UI that tells the player that they are already on a Quest
                return;
            }
            
            manager.AcceptQuest();
        }
        [ContextMenu("CompleteQuest")]
        private void CompleteQuest()
        {
            GetComponent<QuestManager>().CompleteQuest();
            
            heartEffect.Play();
            SoundManager.PlaySound("Quest Complete");
            StartCoroutine("SpitCredits");
        }
        
        private IEnumerator SpitCredits()
        {
            for (int i = 0; i < 10; i++)
            {
                float angle = Random.Range(0, 360) * Mathf.Deg2Rad;
                float x = Mathf.Cos(angle);
                float y = Mathf.Sin(angle);
                
                float spitForce = Random.Range(85, 150);
                GameObject credit = Instantiate(CreditPrefab, transform.position, quaternion.identity);
                credit.GetComponent<Rigidbody2D>().AddForce(new Vector2(x,y) * spitForce);
                yield return new WaitForSeconds(0.35f);
            }
        }
    }
    
    
}