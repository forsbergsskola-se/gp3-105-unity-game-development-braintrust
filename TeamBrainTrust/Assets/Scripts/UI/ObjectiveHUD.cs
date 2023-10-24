using System;
using Quest;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class ObjectiveHUD : MonoBehaviour
    {
        public UnityEvent<string> OnUpdateObjective = new UnityEvent<string>();
        public TextMeshProUGUI infoText;


        private void Start()
        {
            OnUpdateObjective.AddListener(UpdateObjectiveUI);
            QuestManager.i.OnQuestAccepted.AddListener(DisplayUI);
            QuestManager.i.OnQuestCompleted.AddListener(HideUI);
            
            HideUI();
        }

        public void DisplayUI()
        {
            gameObject.SetActive(true);
        }
        
        public void HideUI()
        {
            gameObject.SetActive(false);
        }

        public void UpdateObjectiveUI(string objectiveText)
        {
            infoText.text = objectiveText;
        }
    }
}