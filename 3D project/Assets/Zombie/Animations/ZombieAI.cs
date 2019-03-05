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
    bool deadOfZombie = false;
    // gives the full missing life back
    float missingLife = 1;
    // Start is called before the first frame update
    void Start()
    {   //Initialize the parameters of agent and animator
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // caclulate the distance between the target (FPSController) and the agent IA (Alien)
        distance = Vector3.Distance(target2Follow.transform.position, transform.position);
        // set condition
        if (Dead() == true)
        {
            // call the method "Finish" which is locate in the class of GameOver
            //GameObject.FindWithTag("PanelGameOver").GetComponent<GamesOver>().Finish();
        }
        else
        {
            if (distance < distance2Follow)
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

            deadOfZombie = true;

            GetComponent<NavMeshAgent>().enabled = false;

            GetComponent<CapsuleCollider>().enabled = false;

            anim.SetBool("walk", false);
            anim.SetBool("attack", false);
        }
        return deadOfZombie;
    }

}

