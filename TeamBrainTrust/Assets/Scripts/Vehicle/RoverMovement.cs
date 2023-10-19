using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Vehicle
{
    public class RoverMovement : MonoBehaviour
    {
        public int durability;
        
        public float maxSpeed;
        public float acceleration;
        public float deceleration;
        public float breakPower;
        public float turnSpeed;
        private float yInput;
        private float currentSpeed;
        private bool isBreaking;
        private void Update()
        {
            if (GetComponent<RoverPilot>().isPlayerInRover)
            {
                DriveInput();
                Turn();
            
            }
        }
        
        
        private void FixedUpdate()
        {
            RoverVerticalMovement();
        }

        private void DriveInput()
        {
            if (Input.GetButton("Break"))
            {
                Break(breakPower);
                return;
            }

            yInput = Input.GetAxisRaw("Vertical");
            if (yInput == 0)
            {
                Break(deceleration);
            }
            else if (currentSpeed <= maxSpeed)
            {
                currentSpeed += acceleration * Time.deltaTime;
                isBreaking = false;
            }
        }


        void RoverVerticalMovement()
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = currentSpeed * transform.up;
            
        }

        void Turn()
        {
            
            if (Input.GetButton("Horizontal"))
            {
                transform.Rotate(0, 0, -Input.GetAxisRaw("Horizontal") * turnSpeed * Time.deltaTime);
            }
        }


        void Break(float power)
        {
            isBreaking = true;
            
            if (currentSpeed != 0)
            {
                currentSpeed = Mathf.Lerp(currentSpeed, 0, power * Time.deltaTime);
            }
        }
    }
}
