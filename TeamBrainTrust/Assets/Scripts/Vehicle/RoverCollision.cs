using System;
using UnityEngine;

namespace Vehicle
{
    public class RoverCollision : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            
            int damage = (int)(10 * rb.velocity.magnitude);
            GetComponent<RoverStats>().TakeDamage(damage);

            GetComponent<RoverMovement>().currentSpeed = 0;

        }
        
    }
}