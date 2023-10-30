using System;
using General;
using UnityEngine;
using UnityEngine.UIElements;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public int speed;
        private float xInput;
        private float yInput;


        private void Start()
        {
            FindFirstObjectByType<CameraFollower>().SetTarget(gameObject, speed);
        }

        private void Update()
        {
            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Vertical");
            
            GetComponent<Animator>().SetInteger("Vertical Movement", (int)yInput);
            GetComponent<Animator>().SetInteger("Horizontal Movement", (int)xInput);
        }

        private void FixedUpdate()
        { 
           // transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime,Input.GetAxisRaw("Vertical") * speed * Time.deltaTime ,0);
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2( xInput * speed,
                 yInput * speed);
        }
    }
    
}