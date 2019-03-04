/// <summary>
/// Health.cs
/// Author: MutantGopher
/// This is a sample health script.  If you use a different script for health,
/// make sure that it is called "Health".  If it is not, you may need to edit code
/// referencing the Health component from other scripts
/// </summary>

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth2 : MonoBehaviour
{


    public GameObject spawn;
    public Image damageImage;
    public Color flashColour = new Color(1f, 0f, 0f, 0.25f);
    bool damaged = false;
    public Slider healthSlider;
    AudioSource playerAudio;
    public GameObject screenFader;


    public bool canDie = true;                  // Whether or not this health can die

    public float startingHealth = 100.0f;       // The amount of health to start with
    public float maxHealth = 100.0f;            // The maximum amount of health
    public float currentHealth;                // The current ammount of health
    public float flashSpeed = 5f;
    public bool replaceWhenDead = false;        // Whether or not a dead replacement should be instantiated.  (Useful for breaking/shattering/exploding effects)
    public GameObject deadReplacement;          // The prefab to instantiate when this GameObject dies
    public bool makeExplosion = false;          // Whether or not an explosion prefab should be instantiated
    public GameObject explosion;                // The explosion prefab to be instantiated

    public bool isPlayer = false;               // Whether or not this health is the player
    public GameObject deathCam;                 // The camera to activate when the player dies

    private bool dead = false;                  // Used to make sure the Die() function isn't called twice

    // Use this for initialization
    void Start()
    {
        // Initialize the currentHealth variable to the value specified by the user in startingHealth
        currentHealth = startingHealth;
        playerAudio = transform.GetChild(0).GetComponent<AudioSource>();
    }

    void Update()
    {
        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
            playerAudio.Play();
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
        healthSlider.value = currentHealth;
    }
    public void ChangeHealth(float amount)
    {
        damaged = true;
        // Change the health by the amount specified in the amount variable
        currentHealth += amount;
        

        // If the health runs out, then Die.
        if (currentHealth <= 0 && !dead && canDie)
            Die();

        // Make sure that the health never exceeds the maximum health
        else if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public void Die()
    {
        // This GameObject is officially dead.  This is used to make sure the Die() function isn't called again
        dead = true;
        //deathCam.SetActive(true);
        GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
        GetComponentInChildren<Weapon>().enabled = false;
        GetComponent<AudioSource>().enabled = false;
        playerAudio.enabled = false;
        screenFader.SetActive(true);
        StartCoroutine(Cooldwn(3.0f));
    }

    IEnumerator Cooldwn(float timer)
    {
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //deathCam.SetActive(false);
        //GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
        //GetComponent<AudioSource>().enabled = true;
        //GetComponentInChildren<Weapon>().enabled = true;
        //currentHealth = 100;
        //healthSlider.value = currentHealth;
        //transform.position = spawn.transform.position;
        //dead = false;
        //screenFader.SetActive(false);

    }
}
