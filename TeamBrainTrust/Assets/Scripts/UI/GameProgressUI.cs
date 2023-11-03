using General;
using TMPro;
using UnityEngine;
using Quest;

namespace UI
{
    public class GameProgressUI : MonoBehaviour
    {
        int progressValue;
        public SpaceShip SpaceShip;
        
        private void Start()
        {
            QuestManager.i.OnQuestCompleted.AddListener(UpdateShipUI);
            SpaceShip.OnTakeOff.AddListener(OnTakeOff);
            GetComponent<TextMeshProUGUI>().text = $"{progressValue}% Repaired";
        }

        private void OnTakeOff()
        {
            gameObject.SetActive(false);
        }
        
        private void UpdateShipUI() // Updates text in UI
        {
            progressValue += 25;
            GetComponent<TextMeshProUGUI>().text = $"{progressValue}% Repaired";
        }
    }
}