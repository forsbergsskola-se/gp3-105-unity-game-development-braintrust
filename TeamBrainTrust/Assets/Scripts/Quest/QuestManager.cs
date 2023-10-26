using System;
using UnityEngine;
using Compounds;
using Player;
using UI;
using UnityEngine.Events;

namespace Quest
{
    public class QuestManager : MonoBehaviour
    {
        public static QuestManager i;
        
        [HideInInspector] public UnityEvent OnQuestAccepted = new UnityEvent();
        [HideInInspector] public UnityEvent OnQuestCompleted = new UnityEvent();
        
        
        public Compound[] compounds;
        [HideInInspector] public int cratesLoaded;
        [HideInInspector] public int cratesRequired;
        [HideInInspector] private int questCompleteCount;
        [HideInInspector] public bool isObjectiveCompleted;
        [HideInInspector] public bool questActive;


        public State state;
        public enum State
        {
            AcceptQuest,
            EnterRover1,
            EnterCompound,
            ExitRover,
            LoadCrates,
            EnterRover2,
            CompleteQuest
        }
        
        enum Direction {North, East, South, West};

        private void Awake()
        {
            i = this;
        }

        private void Start()
        {
        }

        private void OnExitRover()
        {
            UpdateObjective(@$"Load crates ( {cratesLoaded} / {cratesRequired} )");

        }

        private void OnEnterRover()
        {
            UpdateObjective("");
        }

        //Accept new quest and setup the variables for the objectives
        public void AcceptQuest()
        {
            questActive = true;
            cratesRequired = 4;
            //cratesRequired = compounds[questCompleted].crates;  //Get the current compound and the amount of crates that is contained in that compound
            isObjectiveCompleted = false;
            cratesLoaded = 0;
            
            compounds[questCompleteCount].SetIsObjective(true);

            UpdateObjective("Get to the Compound");
            OnQuestAccepted.Invoke();
        }

        public void OnEnterCompound()
        {
            UpdateObjective("Exit Rover");
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
            state++;
        }
        public void CompleteQuest()
        {
            compounds[questCompleteCount].SetIsObjective(false);
            questCompleteCount++;

            questActive = false;
            OnQuestCompleted.Invoke();
        }

    }
    
}