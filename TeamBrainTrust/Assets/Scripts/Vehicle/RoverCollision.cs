using System;
using UnityEngine;

namespace Vehicle
{
    public class RoverCollision : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            int damage = (int)GetComponent<RoverMovement>().currentSpeed;
            damage = Mathf.Abs(damage);
            
            GetComponent<RoverStats>().TakeDamage(damage);
            GetComponent<RoverMovement>().currentSpeed = 0;
        }
    }
}