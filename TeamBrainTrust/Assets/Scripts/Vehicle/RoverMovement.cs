using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Vehicle
{
    public class RoverMovement : MonoBehaviour
    {
        public int durability;
        
        public float maxSpeed;
        public float maxReverseSpeed;
        public float acceleration;
        public float breakPower;
        public float turnSpeed;
        
        private float currentSpeed;
        
        private void Update()
        {
            if (GetComponent<RoverPilot>().isPlayerInRover)
            {
                SetCurrentSpeed();
                Turn();
            
                transform.Translate(0,  currentSpeed * Time.deltaTime, 0,Space.Self);
            }
        }
        
        private void SetCurrentSpeed()
        {
            if (Input.GetButton("Break"))
            {
                Break();
            }
            else if (Input.GetButton("Vertical"))
            {
                
                if(Input.GetAxisRaw("Vertical") > 0)//Press Up button to begin accelerating
                {
                    if (currentSpeed <= maxSpeed)
                    {
                        currentSpeed += acceleration * Time.deltaTime;
                    }
                }
                else if(Input.GetAxisRaw("Vertical") < 0) //Press Down button to begin reversing
                {
                    if (currentSpeed > maxReverseSpeed)
                    {
                        currentSpeed -= acceleration * Time.deltaTime;
                    }
                }
                else //If pressing both Up & Down, car breaks
                {
                    Break();
                }
            }
            else //If no input, slow down
            {
                Break();
            }
            
        }

        void Turn()
        {
            if (Input.GetButton("Horizontal"))
            {
                transform.Rotate(0, 0, -Input.GetAxisRaw("Horizontal") * turnSpeed * Time.deltaTime);
            }
        }


        void Break()
        {
            if (currentSpeed != 0)
            {
                currentSpeed = Mathf.Lerp(currentSpeed, 0, breakPower);
            }
        }
        
        
        
    }



   
}
