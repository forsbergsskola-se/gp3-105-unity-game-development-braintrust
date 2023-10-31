using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public string targetSceneName;
        
        public void LoadScene()
        {
            SceneManager.LoadScene(targetSceneName);
        }
        
        public void EndGame()
        {
            Application.Quit();
        }

        public void OpenGameRules()
        {
            
        }
    }
    
    
}