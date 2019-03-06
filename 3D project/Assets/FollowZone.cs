using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
            transform.parent.tag= "Enabled";
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            transform.parent.tag = "Disabled";
    }
    // Start is called before the first frame update
}
