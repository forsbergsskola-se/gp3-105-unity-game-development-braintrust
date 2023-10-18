using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    
    public GameObject player;

    private void LateUpdate()
    {
        if (player.activeSelf)
        {
            Vector3 target = player.transform.position + new Vector3(0, 0, -7.5f);
            transform.position = target;
        }
    }
    
}
