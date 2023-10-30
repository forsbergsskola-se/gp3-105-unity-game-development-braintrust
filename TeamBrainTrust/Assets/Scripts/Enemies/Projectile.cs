using System;
using Player;
using UnityEngine;
using General;

namespace Enemies
{
    public class Projectile : MonoBehaviour
    {
        public float speed;
        public int damage;

        public float lifeTime;

        private void Update()
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);

            lifeTime -= Time.deltaTime;

            if (lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log(LayerMask.LayerToName(other.gameObject.layer));
            
            if (other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("Rover"))
            {
                other.gameObject.GetComponent<Stats>().TakeDamage(damage);
            }
            
            Destroy(gameObject);
        }
    }
}