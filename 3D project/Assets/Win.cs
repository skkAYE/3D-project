using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject winFader;
    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player") { 
        player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
        player.GetComponentInChildren<Weapon>().enabled = false;
        player.GetComponent<AudioSource>().enabled = false;
        player.transform.GetChild(0).GetComponent<AudioSource>().enabled = false;
        winFader.SetActive(true);
        }
    }

}
