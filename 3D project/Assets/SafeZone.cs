using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            GameObject.Find("Spawner_2").tag = "Disabled";
            GameObject.Find("Spawner_3").tag = "Disabled";
            GameObject.Find("Spawner_4").tag = "Disabled";
            GameObject.Find("Spawner_5").tag = "Disabled";
            GameObject.Find("Spawner_6").tag = "Disabled";

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            GameObject.Find("Spawner_2").tag = "Enabled";
            GameObject.Find("Spawner_3").tag = "Enabled";
            GameObject.Find("Spawner_4").tag = "Enabled";
            GameObject.Find("Spawner_5").tag = "Enabled";
            GameObject.Find("Spawner_6").tag = "Enabled";

    }
}
