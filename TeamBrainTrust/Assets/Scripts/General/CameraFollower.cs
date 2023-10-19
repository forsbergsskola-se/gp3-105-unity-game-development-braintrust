using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using General;
using Player;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private void FixedUpdate()
    {
        PlayerStats player = FindFirstObjectByType<PlayerStats>();;
        
        
        if (player.rover == null)
        {
            FollowTarget(player.gameObject);
        }
        else
        {
            FollowTarget(player.rover.gameObject);
        }
    }

    private void FollowTarget(GameObject target)
    {
        Vector3 targetPosition = target.transform.position + new Vector3(0, 0, -7.5f);
        transform.position = targetPosition;
    }
    
}
