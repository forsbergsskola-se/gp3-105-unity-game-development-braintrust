using System;
using UnityEngine;

namespace Enemies
{
    public class Projectile : MonoBehaviour
    {
        public float speed;
        public int damage;

        private void Update()
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);
        }

        public void SetupProjectile(Vector3 rotation)
        {
            transform.Rotate(rotation);
            
        }
    }
}