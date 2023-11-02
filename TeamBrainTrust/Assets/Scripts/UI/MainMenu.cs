using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public string targetSceneName;
        public Transform gameRulesTransform;
        
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
            gameRulesTransform.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        public void CloseGameRules()
        {
            gameRulesTransform.gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
    }
    
    
}