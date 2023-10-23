using UnityEngine;
using General;
using Player;

namespace Quest
{
    public class QuestGiver : MonoBehaviour
    {
        
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
                    GiveReward();
                }
                return;
            }
            
            manager.GetNewQuest();
        }

        private void GiveReward()
        {
            GetComponent<QuestManager>().questActive = false;
        }
        
    }
    
    
}