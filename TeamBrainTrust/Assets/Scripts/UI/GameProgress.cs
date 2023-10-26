using TMPro;
using UnityEngine;
using Quest;

namespace UI
{
    public class GameProgress : MonoBehaviour
    {
        public int progressValue;

        private void Start()
        {
            QuestManager.i.OnQuestCompleted.AddListener(UpdateShipUI);

        }

        public void UpdateShipUI() // Updates text in UI
        {
            progressValue = 25;
            GetComponent<TextMeshProUGUI>().text = $"{progressValue}% COMPLETED";
        }
    }
}