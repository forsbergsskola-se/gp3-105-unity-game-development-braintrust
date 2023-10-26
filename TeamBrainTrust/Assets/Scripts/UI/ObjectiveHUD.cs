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
        

        public void UpdateObjectiveUI(string objectiveText)
        {
            infoText.text = objectiveText;
        }
    }
}