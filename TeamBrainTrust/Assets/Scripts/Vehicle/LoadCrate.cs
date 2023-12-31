using System;
using General;
using Player;
using Quest;
using Systems.General;
using UnityEngine;

namespace Vehicle
{
    public class LoadCrate : MonoBehaviour
    {
        public Transform cratesTransform;
        
        private void Start()
        {
            GetComponent<Interactable>().onInteraction.AddListener(LoadCrateOnRover);
            QuestManager.i.OnQuestCompleted.AddListener(UnloadCrateFromRover);
        }

        private void LoadCrateOnRover(GameObject player)
        {
            if(player.GetComponent<PlayerStats>().itemInHand == null)
                return;
            
            for (int i = 0; i < 4; i++)
            {
                Transform child = cratesTransform.GetChild(i);

                if (!child.gameObject.activeSelf)
                {
                    child.gameObject.SetActive(true);
                    Destroy(player.GetComponent<PlayerStats>().itemInHand.gameObject);
                    
                    SoundManager.PlaySound("Place Crate");
                    QuestManager.i.LoadCrate();
                    
                    return;
                }
            }
            
        }
        public void UnloadCrateFromRover()
        {
            for (int i = 0; i < 4; i++)
            {
                Transform child = cratesTransform.GetChild(i);
                child.gameObject.SetActive(false);
            }
        }
    }
}