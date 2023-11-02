using Systems.General;
using UnityEngine;

namespace UI
{
    public class Win_Scene : MonoBehaviour
    {
        private void Start()
        {
            //Play Win Music
            //SoundManager.PlaySound("Main Menu Music");
        }
        
        public void EndGame()
        {
            Application.Quit();
        }
        
    }
}