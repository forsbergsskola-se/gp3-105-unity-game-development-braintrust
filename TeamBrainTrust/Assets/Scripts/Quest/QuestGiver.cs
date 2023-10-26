using System.Collections;
using UnityEngine;
using General;
using Player;
using UI;
using Unity.Mathematics;
using Random = UnityEngine.Random;

namespace Quest
{
    public class QuestGiver : MonoBehaviour
    {
        public GameObject CreditPrefab;
        
        private void Start()
        {
            GetComponent<Interactable>().onInteraction.AddListener(Interact);
        }

        private void Interact(GameObject player)
        {
            QuestManager manager = GetComponent<QuestManager>();
            
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
        [ContextMenu("CoinTest")]
        private void CompleteQuest()
        {
            GetComponent<QuestManager>().CompleteQuest();
            StartCoroutine("SpitCredits");
        }
        
        private IEnumerator SpitCredits()
        {
            for (int i = 0; i < 10; i++)
            {
                float x = Random.Range(-1, 1);
                float y = Random.Range(-1, 1);
                float spitForce = Random.Range(10, 100);
                GameObject credit = Instantiate(CreditPrefab, transform.position, quaternion.identity);
                credit.GetComponent<Rigidbody2D>().AddForce(new Vector2(x,y) * spitForce);
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    
    
}