using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// to use the AI you must importe this package
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    // create the AI agent
    NavMeshAgent agent;
    // set the target the AI must to follow
    public GameObject target2Follow;
    public GameObject spawner;
    // set the ditance to Attack
    public float distance2Attack = 5.0f;
    // set the diatance to follow
    public float distance2Follow = 50.0f;
    // the animator controller
    Animator anim;
    // As distance is declare as private, we should used [SerializeField] to make it visible in Unity field
    [SerializeField]
    private float distance;
    // to test de dead of the allien
    bool alreadyDead = false;
    // gives the full missing life back
    float missingLife = 1;
    // Start is called before the first frame update
    void Start()
    {   //Initialize the parameters of agent and animator
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        target2Follow = GameObject.Find("FpsControllerWithAWeapon Variant");

        string spawn = "Spawner_";
        string tmp = GetComponent<Health_Zombie>().name.Replace("(Clone)", "");
        spawn = spawn + tmp;
        Debug.Log(spawn);
            if (GetComponent<Health_Zombie>().startingHealth==200)
            spawner = GameObject.Find("Spawner_1");
        else if (GetComponent<Health_Zombie>().startingHealth == 250)
            spawner = GameObject.Find(spawn);
        else
            spawner = GameObject.Find(spawn);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // caclulate the distance between the target (FPSController) and the agent IA (Alien)
        distance = Vector3.Distance(target2Follow.transform.position, transform.position);
        // set condition
        if ((GetComponent<Health_Zombie>().dead && !alreadyDead) || (GetComponent<Health_Zombie>().startingHealth == 250 && spawner.tag=="Disabled" && !alreadyDead))
        {
            anim.SetTrigger("dead");
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            anim.SetBool("walk", false);
            anim.SetBool("attack", false);
            alreadyDead = true;
            StartCoroutine(Cooldwn(5.0f));

        }
        else if (alreadyDead) { }
        else
        {
            if (distance < distance2Follow && spawner.tag=="Enabled")
            {
                // tell the agent that it must to follow the target
                agent.SetDestination(target2Follow.transform.position);
                if (distance < distance2Attack)
                {   // call the boolean  on the parmater of the animator
                    anim.SetBool("walk", false);
                    anim.SetBool("attack", true);
                    // in the attack, tell the agent do not move
                    agent.SetDestination(transform.position);
                }
                else
                {
                    // call the boolean...
                    anim.SetBool("walk", true);
                    anim.SetBool("attack", false);
                }
            }
            else
            {
                anim.SetBool("walk", false);
                anim.SetBool("attack", false);
                // when all is false, the agent must return in idle mode, and not move
                agent.SetDestination(transform.position);
            }
        }
    }

    // to simulate the dead animation of the alien ,press D 
    public bool Dead()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {

            anim.SetTrigger("dead");

            alreadyDead = true;

            GetComponent<NavMeshAgent>().enabled = false;

            GetComponent<CapsuleCollider>().enabled = false;

            anim.SetBool("walk", false);
            anim.SetBool("attack", false);
        }
        return alreadyDead;
    }
    public void Attack(float damage)
    {
        GameObject.Find("FpsControllerWithAWeapon Variant").gameObject.SendMessageUpwards("ChangeHealth", -damage, SendMessageOptions.DontRequireReceiver);
    }
    private IEnumerator Cooldwn(float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
        if(spawner.GetComponent<Spawning_prefab>().currentSpawn>0)
            spawner.GetComponent<Spawning_prefab>().currentSpawn--;
    }

}

