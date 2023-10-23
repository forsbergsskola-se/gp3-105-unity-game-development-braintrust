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

        public void GetNewQuest()
        {
            
        }

        public void EnterCompound()
        {
            
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
            
        }

    }
    
}