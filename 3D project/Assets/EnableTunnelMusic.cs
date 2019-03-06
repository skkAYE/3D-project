using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTunnelMusic : MonoBehaviour
{

    bool hasStarted = false;


    private void OnTriggerEnter(Collider other)
    {
        if (!hasStarted)
        {
            if (other.tag == "Player")
                transform.parent.GetComponent<AudioSource>().Play();
        }
        else
        {
            if (other.tag == "Player")
                transform.parent.GetComponent<AudioSource>().UnPause();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            transform.parent.GetComponent<AudioSource>().Pause();
    }
}
