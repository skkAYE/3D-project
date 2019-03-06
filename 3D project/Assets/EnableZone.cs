using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            transform.parent.GetComponent<Spawning_prefab>().isEnabled = true;
    }
}
