using System;
using Player;
using UnityEngine;

namespace General
{
    public class CameraFollower : MonoBehaviour
    {
        private GameObject target;
        public float maxDistance = 0.5f;
        private float targetSpeed;

        private void LateUpdate()
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
            //transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * targetSpeed / maxDistance);
            transform.position = Vector3.Lerp(transform.position, targetPosition,
                Time.deltaTime * (targetSpeed / maxDistance));
        }

    }
}