﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnOnTrigger : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.transform.position = respawnPoint.position;
        }


    }
}