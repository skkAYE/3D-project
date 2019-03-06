using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnInvisible : MonoBehaviour
{
    GameObject Weapons;
    private void Start()
    {
        Weapons = GameObject.Find("Weapons");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            Weapons.gameObject.SetActive(false);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            Weapons.gameObject.SetActive(true);

    }
}
