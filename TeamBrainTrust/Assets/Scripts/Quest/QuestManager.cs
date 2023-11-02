using System;
using UnityEngine;
using Compounds;
using Player;
using Systems.General;
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
        [HideInInspector] public UnityEvent OnSpaceShipRepaired = new UnityEvent();

        
        public Compound[] compounds;
        [HideInInspector] public int cratesLoaded;
        [HideInInspector] public int cratesRequired;
        [HideInInspector] private int questCompleteCount;
        [HideInInspector] public bool isObjectiveCompleted;
        [HideInInspector] public bool questActive;

        public State state;
        public enum State
        {
            NoQuest, //TALK TO BEBOP TO GET A QUEST
            EnterRover1, //ENTER ROVER
            EnterCompound, //GET TO THE COMPOUND
            ExitRover1, //EXIT ROVER
            LoadCrates, //LOAD CRATES X/4
            EnterRover2, //ENTER ROVER
            // RETURN TO QUESTGIVER WITH CRATES, IF ROVER BREAKS, GET A NEW ONE AND REPEAT LOAD CRATES
            CompleteQuest // GET REWARD
        }
        
        private void Awake()
        {
            i = this;
        }

        private void Start()
        {
            PlayerStats.i.OnEnterRover.AddListener(OnEnterRover);
            PlayerStats.i.OnExitRover.AddListener(OnExitRover);
            
            questCompleteCount = PlayerPrefs.GetInt("QuestCompleteCount", questCompleteCount);
            questCompleteCount = 0;
            PrepareQuest();
        }


        private void PrepareQuest()
        {
            state = State.NoQuest;

            if (questCompleteCount == 4)
            {
                UpdateObjective("Enter Spaceship to return to Earth");
                OnSpaceShipRepaired.Invoke();
                return;
            }
            
            UpdateObjective("Speak to B33P B00P to Receive a Quest");
        }
        


        //Accept new quest and setup the variables for the objectives
        public void AcceptQuest()
        {
            questActive = true;
            cratesRequired = 4;
            isObjectiveCompleted = false;
            cratesLoaded = 0;

            UpdateObjective("Enter Rover");
            SoundManager.PlaySound("Objective Complete");
            
            OnQuestAccepted.Invoke();
        }

        public void OnEnterCompound()
        {
            if(state == State.EnterCompound)
                UpdateObjective("Exit Rover");
            SoundManager.PlaySound("Objective Complete");
        }


        public void LoadCrate()
        {
            cratesLoaded++;
            UpdateObjective(@$"Load crates ({cratesLoaded} / {cratesRequired})");
            SoundManager.PlaySound("Objective Complete");
            
            if (cratesLoaded == cratesRequired) //When all crates are loaded the quest is completed and ready to hand in to quest giver
                ObjectiveCompleted();
        }

        public void ObjectiveCompleted()
        {
            isObjectiveCompleted = true;
            UpdateObjective("Return crates to B33P B00P");
            SoundManager.PlaySound("Objective Complete");
        }
        

        public void UpdateObjective(string objectiveInfo)
        {
            ObjectiveHUD.i.OnUpdateObjective.Invoke(objectiveInfo);

            if (state == State.LoadCrates && cratesLoaded < cratesRequired)
                return;
            
            state++;
        }
        
        public void CompleteQuest()
        {
            compounds[questCompleteCount].SetIsObjective(false);
            questCompleteCount++;

            questActive = false;
            PrepareQuest();
            PlayerPrefs.SetInt("QuestCompleteCount", questCompleteCount);
            OnQuestCompleted.Invoke();
        }
        
        private void OnExitRover()
        {
            if (state == State.ExitRover1)
            {
                UpdateObjective(@$"Load crates ({cratesLoaded} / {cratesRequired})");
                SoundManager.PlaySound("Objective Complete");
            }
        }

        private void OnEnterRover()
        {
            if (state == State.EnterRover1)
            {
                UpdateObjective($"Get to the {compounds[questCompleteCount].gameObject.name} ");
                SoundManager.PlaySound("Objective Complete");
                compounds[questCompleteCount].SetIsObjective(true);
            }
            else if(state == State.EnterRover2)
            {
                UpdateObjective("Return to B33P B00P with crates");
                SoundManager.PlaySound("Objective Complete");
            }
        }
    }
}
