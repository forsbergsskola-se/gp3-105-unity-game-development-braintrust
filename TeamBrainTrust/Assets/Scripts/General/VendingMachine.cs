using System.Collections;
using UnityEngine;
using General;
using Player;
using UI;
using Unity.Mathematics;
using Random = UnityEngine.Random;

namespace General
{
    public class VendingMachine : MonoBehaviour
    {
        public GameObject consumablePrefab;
        public int cost;
        
        private Vector2 spitForceInterval = new Vector2(85, 150);
        
        private void Start()
        {
            GetComponent<Interactable>().onInteraction.AddListener(OnInteraction);
        }

        private void OnInteraction(GameObject player)
        {
            if (player.GetComponent<PlayerStats>().creditCount >= cost)
            {
                SpitConsumable();
                player.GetComponent<PlayerStats>().creditCount -= cost;
                PlayerHUD.i.UpdateCredits();
            }
        }


        private void SpitConsumable()
        {
            float angle = Random.Range(0, 360) * Mathf.Deg2Rad;
            float x = Mathf.Cos(angle);
            float y = Mathf.Sin(angle);
            
            float spitForce = Random.Range(spitForceInterval.x, spitForceInterval.y);
            GameObject credit = Instantiate(consumablePrefab, transform.position, quaternion.identity);
            credit.GetComponent<Rigidbody2D>().AddForce(new Vector2(x,y) * spitForce);
        }
    }
}