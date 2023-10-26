using TMPro;
using UnityEngine;
using Quest;
namespace UI
{
    public class GameProgress : MonoBehaviour
    {
        public TextMeshProUGUI progressText;
        public int progressValue;
        private void Start()
        {
            GetComponent<QuestManager>().OnQuestCompleted.AddListener(UpdateShipUI);
            
        }
        public void UpdateShipUI() // Updates text in UI
        {
            progressValue = 25;
            progressText.text = $"{progressValue}% COMPLETED";
        }
    }
    
    
    
    
    
    /// public TextMeshProUGUI scoreText;
    /// public int scoreCount;
    
    /* public void UpdateScore()
    {

    scoreCount = 25;
    scoreText.text = $"{scoreCount}% COMPLETED";
            
            

    }*/
}