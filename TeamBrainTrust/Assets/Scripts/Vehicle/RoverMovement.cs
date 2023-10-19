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
            
                transform.Translate(0,  currentSpeed * Time.deltaTime, 0,Space.Self);
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
            else
            {
                currentSpeed += acceleration + Time.deltaTime;
                isBreaking = false;
            }
        }


        void RoverVerticalMovement()
        {
            if (isBreaking)
            {
                return;
            }
            
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, yInput * currentSpeed);
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
