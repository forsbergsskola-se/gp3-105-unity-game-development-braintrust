using System;
using UnityEngine;
using Compounds;
using Player;
using UI;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

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
            NoQuest,
            AcceptQuest,
            EnterRover1,
            EnterCompound,
            ExitRover1,
            LoadCrates,
            EnterRover2,
            ExitRover2,
            CompleteQuest
        }
        
        private void Awake()
        {
            i = this;
        }

        private void Start()
        {
            PlayerStats.i.OnEnterRover.AddListener(OnEnterRover);
            PlayerStats.i.OnExitRover.AddListener(OnExitRover);
            
            PrepareQuest();
        }

        private void PrepareQuest()
        {
            UpdateObjective("Speak to Beep Boop to Receive a Quest");
            state = State.NoQuest;
        }
        

        private void OnExitRover()
        {
            if (state == State.ExitRover1)
            {
                UpdateObjective(@$"Load crates ( {cratesLoaded} / {cratesRequired} )");
            }
            else if(state == State.ExitRover2)
            {
                UpdateObjective("Speak to the Beep Boop to CompleteQuest");
            }
        }

        private void OnEnterRover()
        {
            if (state == State.EnterRover1)
            {
                UpdateObjective("Get to the Compound");
                compounds[questCompleteCount].SetIsObjective(true);
            }
            else if(state == State.EnterRover2)
            {
                UpdateObjective("Return to Quest Giver");
            }
        }

        //Accept new quest and setup the variables for the objectives
        public void AcceptQuest()
        {
            questActive = true;
            cratesRequired = 4;
            //cratesRequired = compounds[questCompleted].crates;  //Get the current compound and the amount of crates that is contained in that compound
            isObjectiveCompleted = false;
            cratesLoaded = 0;
            

            UpdateObjective("Enter Rover");
            state = State.AcceptQuest;
            
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
                ObjectiveCompleted();
        }

        public void ObjectiveCompleted()
        {
            isObjectiveCompleted = true;
            UpdateObjective("Return crates to Beep Boop");
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
            PrepareQuest();
            OnQuestCompleted.Invoke();
        }

    }
    
}