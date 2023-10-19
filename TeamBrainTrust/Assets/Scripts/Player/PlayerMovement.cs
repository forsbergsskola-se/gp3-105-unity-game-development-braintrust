using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public int speed;


        private void Start()
        {
            FindFirstObjectByType<CameraFollower>().SetTarget(gameObject, speed);
        }

        private void Update()
        { 
            transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime,Input.GetAxisRaw("Vertical") * speed * Time.deltaTime ,0);
        }
    }
    
}