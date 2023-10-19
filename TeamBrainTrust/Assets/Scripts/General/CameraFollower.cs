using System;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace General
{
    public class CameraFollower : MonoBehaviour
    {
        private GameObject target;
        public float targetOffset = 2.5f;
        public float delayAmount = 50f;
        private float targetSpeed;
        

        private void FixedUpdate()
        {
            FollowTarget();
        }

        public void SetTarget(GameObject target, float targetSpeed)
        {
            this.target = target;
            this.targetSpeed = targetSpeed;
        }

        private void FollowTarget()
        {
            if(target == null)
                return;
            
            Vector3 targetPosition = target.transform.position + new Vector3(0, 0, -7.5f);
            
            targetPosition += GetOffset();
            
            transform.position = Vector3.Lerp(transform.position, targetPosition,
                targetSpeed / delayAmount);
            
        }

        Vector3 GetOffset()
        {
            Rigidbody2D targetRB = target.GetComponent<Rigidbody2D>();
            float offsetAmount = targetRB.velocity.magnitude / targetSpeed;
            
            return targetRB.velocity.normalized * offsetAmount * targetOffset;
        }

    }
}