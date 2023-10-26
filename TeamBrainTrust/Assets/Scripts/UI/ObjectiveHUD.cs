using System;
using Quest;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class ObjectiveHUD : MonoBehaviour
    {
        public static ObjectiveHUD i;
        
        public UnityEvent<string> OnUpdateObjective = new UnityEvent<string>();
        public TextMeshProUGUI infoText;

        private void Awake()
        {
            i = this;

            OnUpdateObjective.AddListener(UpdateObjectiveUI);
        }

        // private void Start()
        // {
        //     // QuestManager.i.OnQuestAccepted.AddListener(DisplayUI);
        //     // QuestManager.i.OnQuestCompleted.AddListener(HideUI);
        //     
        //     // HideUI();
        // }

        // public void DisplayUI()
        // {
        //     gameObject.SetActive(true);
        // }
        //
        // public void HideUI()
        // {
        //     gameObject.SetActive(false);
        // }

        public void UpdateObjectiveUI(string objectiveText)
        {
            Debug.Log("");
            infoText.text = objectiveText;
        }
    }
}