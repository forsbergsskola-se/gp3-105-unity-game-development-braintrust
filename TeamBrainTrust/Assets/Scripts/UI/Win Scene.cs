using Systems.General;
using UnityEngine;

namespace UI
{
    public class Win_Scene : MonoBehaviour
    {
        private void Start()
        {
            SoundManager.PlaySound("Win Scene Music");
            PlayerPrefs.DeleteAll();
        }
        
        public void EndGame()
        {
            Application.Quit();
        }
        
    }
}