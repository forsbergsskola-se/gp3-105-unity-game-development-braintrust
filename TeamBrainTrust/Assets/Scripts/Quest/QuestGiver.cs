using UnityEngine;
using General;
using Player;
using UI;

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
                    CompleteQuest();
                    return;
                    
                }

                //Add popup UI that tells the player that they are already on a Quest
                return;
            }
            
            manager.AcceptQuest();
        }

        private void CompleteQuest()
        {
            GetComponent<QuestManager>().CompleteQuest();
            
        }
        
    }
    
    
}