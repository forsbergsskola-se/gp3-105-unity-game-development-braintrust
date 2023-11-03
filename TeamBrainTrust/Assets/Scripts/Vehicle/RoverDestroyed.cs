using System;
using System.Collections;
using Systems.General;
using UnityEngine;

namespace Vehicle
{
    public class RoverDestroyed : MonoBehaviour
    {
        public ParticleSystem fireEffect;

        private void Start()
        {
            SoundManager.PlaySound("Rover Fire");
            StartCoroutine("StopFire");
        }


        private IEnumerator StopFire()
        {
            yield return new WaitForSeconds(6);
            
            fireEffect.Stop();
            SoundManager.StopSound("Rover Fire");
        }
    }
}