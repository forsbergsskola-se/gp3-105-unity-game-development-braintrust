using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using General;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private void FixedUpdate()
    {
        
        // vi vill använda isPlayerActive från Interactable 
        
        GameObject player = GameObject.Find("Player");
        GameObject rover = GameObject.Find("Rover");
        
        if (player == null)
        {
            return;
        }
/*
        if ()
        {
            Vector3 target = player.transform.position + new Vector3(0, 0, -7.5f);
            transform.position = target;
        }

        if (!)
        {
            Vector3 target = rover.transform.position + new Vector3(0, 0, -7.5f);
            transform.position = target;
        }
        */
    }
    
}
