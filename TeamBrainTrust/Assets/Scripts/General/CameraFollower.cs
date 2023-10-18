using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    
    private void FixedUpdate()
    {
        GameObject player = GameObject.Find("Space Guy");
        if (player == null)
        {
            return;
        }
        Vector3 target = player.transform.position + new Vector3(0, 0, -7.5f);
        transform.position = target;
    }
    
}
