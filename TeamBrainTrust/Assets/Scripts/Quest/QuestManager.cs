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

        public void GetNewQuest()
        {
            Debug.Log("get new quest");
            cratesRequired = compounds[questCompleted].crates;
            isObjectiveCompleted = false;
            cratesLoaded = 0;
        }

        public void EnterCompound()
        {
            Debug.Log("enter compound");
        }

        public void LoadCrate()
        {
            cratesLoaded++;
            if (cratesLoaded == cratesRequired)
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