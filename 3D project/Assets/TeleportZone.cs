using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportZone : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y - 3, other.transform.position.z);
    }
}
