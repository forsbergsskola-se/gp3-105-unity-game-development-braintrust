using System;
using General;
using Player;
using Quest;
using UnityEngine;

namespace Vehicle
{
    public class LoadCrate : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Interactable>().onInteraction.AddListener(LoadCrateOnRover);
        }

        private void LoadCrateOnRover(GameObject player)
        {
            if(player.GetComponent<PlayerStats>().itemInHand == null)
                return;
            
            for (int i = 0; i < 4; i++)
            {
                Transform child = gameObject.transform.GetChild(i);

                if (!child.gameObject.activeSelf)
                {
                    child.gameObject.SetActive(true);
                    Destroy(player.GetComponent<PlayerStats>().itemInHand.gameObject);
                    
                    QuestManager.i.LoadCrate();
                    
                    return;
                }
            }
            
        }
    }
}