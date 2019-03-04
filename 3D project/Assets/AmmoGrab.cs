using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoGrab : MonoBehaviour
{
    public Weapon[] weapons;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.name == "AMMO" && hit.gameObject.GetComponent<MeshRenderer>().enabled==true)
        {
           foreach(Weapon weap in weapons)
            {
                weap.GetComponent<currentStock>().currentTotalAmmo = weap.GetComponent<currentStock>().currentTotalAmmo + weap.GetComponent<Weapon>().ammoCapacity;
            }
            hit.gameObject.GetComponent<AudioSource>().Play();
            hit.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        if (hit.gameObject.name == "HP20" && GetComponent<playerHealth2>().currentHealth<100 && hit.gameObject.GetComponent<MeshRenderer>().enabled == true)
        {
            GetComponent<playerHealth2>().currentHealth = GetComponent<playerHealth2>().currentHealth + 20;
            if (GetComponent<playerHealth2>().currentHealth > 100) GetComponent<playerHealth2>().currentHealth = 100;
            hit.gameObject.GetComponent<AudioSource>().Play();
            hit.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        if (hit.gameObject.name == "HP35" && GetComponent<playerHealth2>().currentHealth < 100 && hit.gameObject.GetComponent<MeshRenderer>().enabled == true)
        {
            GetComponent<playerHealth2>().currentHealth = GetComponent<playerHealth2>().currentHealth + 35;
            if (GetComponent<playerHealth2>().currentHealth > 100) GetComponent<playerHealth2>().currentHealth = 100;
            hit.gameObject.GetComponent<AudioSource>().Play();
            hit.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        if (hit.gameObject.name == "HP50" && GetComponent<playerHealth2>().currentHealth < 100 && hit.gameObject.GetComponent<MeshRenderer>().enabled == true)
        {
            GetComponent<playerHealth2>().currentHealth = GetComponent<playerHealth2>().currentHealth + 50;
            if (GetComponent<playerHealth2>().currentHealth > 100) GetComponent<playerHealth2>().currentHealth = 100;
            hit.gameObject.GetComponent<AudioSource>().Play();
            hit.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

    }
}
