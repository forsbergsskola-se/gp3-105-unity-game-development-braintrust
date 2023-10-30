using UnityEngine;

namespace Player
{
    public class PlayerUI : MonoBehaviour
    {
        public GameObject interactButtonUI;

        public void DisplayUI(bool display)
        {
            interactButtonUI.SetActive(display);
        }
        
    }
}