using System;
using UnityEngine;
using UnityEngine.Serialization;
using Vector2 = System.Numerics.Vector2;

namespace Vehicle
{
    public class RoverMovement : MonoBehaviour
    {
        [Header("Speed")]
        public float maxSpeed;
        public float turnSpeed;
        
        [Header("Acceleration")]
        public float acceleration;
        public float deceleration;
        public float breakPower;
        
        [HideInInspector]public float currentSpeed;
        private float yInput;
        private bool isBreaking;
        private void Update()
        {
            if (GetComponent<RoverPilot>().isPlayerInRover)
            {
                DriveInput();
                Turn();
            
            }
            else
            {
                Break(breakPower);
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
            else if (yInput > 0 && currentSpeed <= maxSpeed)
            {
                currentSpeed += acceleration * Time.deltaTime;
                isBreaking = false;
            }
            else if (yInput < 0 && currentSpeed >= -maxSpeed)
            {
                currentSpeed -= acceleration * Time.deltaTime;
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
