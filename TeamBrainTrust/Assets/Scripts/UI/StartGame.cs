using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class StartGame : MonoBehaviour
    {
        public string targetSceneName;
        
        public void LoadScene()
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }
}