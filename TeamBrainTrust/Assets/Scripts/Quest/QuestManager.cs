using System;
using UnityEngine;
using Compounds;
using UI;
using UnityEngine.Events;

namespace Quest
{
    public class QuestManager : MonoBehaviour
    {
        public static QuestManager i;
        
        public UnityEvent OnQuestAccepted = new UnityEvent();
        public UnityEvent OnQuestCompleted = new UnityEvent();
        
        
        public Compound[] compounds;
        public int cratesLoaded;
        public int cratesRequired;
        private int questCompleted;
        public bool isObjectiveCompleted;
        public bool questActive;


        private void Awake()
        {
            i = this;
        }


        //Accept new quest and setup the variables for the objectives
        public void AcceptQuest()
        {
            questActive = true;
            cratesRequired = compounds[questCompleted].crates;  //Get the current compound and the amount of crates that is contained in that compound
            isObjectiveCompleted = false;
            cratesLoaded = 0;

            UpdateObjective("Get to the Compound");
            OnQuestAccepted.Invoke();
        }

        public void OnEnterCompound()
        {
            UpdateObjective(@$"Load crates ( {cratesLoaded} / {cratesRequired} )");
        }

        public void LoadCrate()
        {
            cratesLoaded++;
            UpdateObjective(@$"Load crates ( {cratesLoaded} / {cratesRequired} )");
            
            if (cratesLoaded == cratesRequired) //When all crates are loaded the quest is completed and ready to hand in to quest giver
            {
                ObjectiveCompleted();
            }
        }

        public void ObjectiveCompleted()
        {
            isObjectiveCompleted = true;
            UpdateObjective("Return to Questgiver with the crates");
        }
        

        public void UpdateObjective(string objectiveInfo)
        {
            ObjectiveHUD.i.OnUpdateObjective.Invoke(objectiveInfo);
        }
        public void CompleteQuest()
        {
            questActive = false;
            OnQuestCompleted.Invoke();
           FindObjectOfType<PlayerHUD>().UpdateScore();
           
           
        }

    }
    
}