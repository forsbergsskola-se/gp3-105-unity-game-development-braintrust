using System;
using UnityEngine;

namespace Vehicle
{
    public class RoverMovement : MonoBehaviour
    {
        public int durability;
        
        public float maxSpeed;
        public float maxReverseSpeed;
        public float acceleration;
        
        private float currentSpeed;
        
        private void Update()
        {
            //Press forward button to begin accelerating
            if (Input.GetAxis("Vertical") > 0)
            {
                if (currentSpeed <= maxSpeed)
                {
                    currentSpeed += acceleration * Time.deltaTime;
                }
            }

            if (Input.GetAxis("Vertical") < 0)
            {
                if (currentSpeed > maxReverseSpeed)
                {
                    currentSpeed -= acceleration * Time.deltaTime;
                }
            }


            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, currentSpeed);

        }
    }
}
