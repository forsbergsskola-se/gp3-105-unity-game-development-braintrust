using UnityEngine;
using General;
using Player;

namespace Quest
{
    public class QuestGiver : MonoBehaviour
    {
        public QuestManager manager;
        private void Start()
        {
            GetComponent<Interactable>().onInteraction.AddListener(Interact);
        }

        private void Interact(GameObject player)
        {
            if (player.GetComponent<PlayerStats>().questActive)
            {
                return;
            }
            
            player.GetComponent<PlayerStats>().questActive = true;
            
            manager.GetNewQuest();
            
        }
    }
    
    
}