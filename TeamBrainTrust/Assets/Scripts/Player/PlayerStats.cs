using System;
using General;
using UnityEngine;
using Vehicle;

namespace Player
{
    public class PlayerStats : Stats
    {
        public RoverPilot rover;
        
        public override void Death()
        {
            base.Death();
        }
    }
}