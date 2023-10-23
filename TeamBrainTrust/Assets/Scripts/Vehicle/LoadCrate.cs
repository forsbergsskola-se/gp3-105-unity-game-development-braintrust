using System;
using General;
using UnityEngine;

namespace Vehicle
{
    public class LoadCrate : MonoBehaviour
    {
        
        private void Start()
        {
            //GetComponent<Interactable>().onInteraction.AddListener();
        }

        private void LoadCrateOnRover()
        {
            gameObject.transform.Find(Crate)
        }
        
    }
}