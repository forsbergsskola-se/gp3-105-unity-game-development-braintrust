using System;
using Systems.General;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public string targetSceneName;
        public Transform gameRulesTransform;

        private void Start()
        {
            SoundManager.PlaySound("Main Menu Music");
        }

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