using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportZone : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (transform.name == "Teleport Zone (1)")
                other.transform.position = new Vector3(84, -2, 77);
            else
                other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y - 3, other.transform.position.z);
        }
    }
}
