using System;
using Player;
using UnityEngine;

namespace General
{
    public class CameraFollower : MonoBehaviour
    {
        private GameObject target;
        public float maxDistance = 0.5f;
        public float targetOffset;
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
            Vector3 targetPosition = target.transform.position + new Vector3(0, 0, -7.5f);
            Vector3 offset = target.GetComponent<Rigidbody2D>().velocity.normalized * targetOffset;
            
            Debug.Log(offset);
            targetPosition += offset;
            
            transform.position = Vector3.Lerp(transform.position, targetPosition,
                Time.deltaTime * maxDistance);
        }

    }
}