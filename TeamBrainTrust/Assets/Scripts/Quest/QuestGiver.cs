using UnityEngine;
using General;
using Player;
using UI;

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
            Instantiate(CreditPrefab, transform.position + new Vector3(1, 0, 0), transform.rotation);

        }
        
    }
    
    
}