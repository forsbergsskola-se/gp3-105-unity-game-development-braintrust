using General;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Vehicle
{
    public class RoverStats : Stats
    {
        [HideInInspector]public PlayerStats playerStats;
        
        public override void Death()
        {
            base.Death();
            
            playerStats.TakeDamage(1);
        }
    }
}