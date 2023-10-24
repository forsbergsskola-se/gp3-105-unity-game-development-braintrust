using UnityEngine;
using Compounds;

namespace Quest
{
    public class QuestManager : MonoBehaviour
    {
        public Compound[] compounds;
        public int cratesLoaded;
        public int cratesRequired;
        private int questCompleted;
        public bool isObjectiveCompleted;
        public bool questActive;

        //Accept new quest and setup the variables for the objectives
        public void GetNewQuest()
        {
            Debug.Log("get new quest");
            
            questActive = true;
            cratesRequired = compounds[questCompleted].crates;  //Get the current compound and the amount of crates that is contained in that compound
            isObjectiveCompleted = false;
            cratesLoaded = 0;
        }

        public void OnEnterCompound()
        {
            Debug.Log("enter compound");
        }

        public void LoadCrate()
        {
            cratesLoaded++;
            if (cratesLoaded == cratesRequired) //When all crates are loaded the quest is completed and ready to hand in to quest giver
            {
                ObjectiveCompleted();
            }
        }

        public void ObjectiveCompleted()
        {
            isObjectiveCompleted = true;
        }

    }
    
}