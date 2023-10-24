using System;
using General;
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
            for (int i = 0; i < 4; i++)
            {
                Transform child = gameObject.transform.GetChild(i);

                if (!child.gameObject.activeSelf)
                {
                    child.gameObject.SetActive(true);
                    return;
                }
            }
            
        }
    }
}