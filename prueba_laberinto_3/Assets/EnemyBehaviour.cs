using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{

    /*public float alertRange;
    public LayerMask playerMask;
    public Transform player;
    public float velocity;

    bool alert;

    void Start()
    {
        
    }

    void Update()
    {
        alert = Physics.CheckSphere(transform.position, alertRange, playerMask);

        if (alert)
        {
            //transform.LookAt(player)
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, player.position.z), velocity * Time.deltaTime);
            
        }
    }

    private void onDrawGizmos() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, alertRange);
    }*/

    public int rutine;
    public float stopwatch;
    public Animator ani;
    public Quaternion angle;
    public float grade;

    public GameObject target;
    public bool attack;

    public EnemyRange range;

    public NavMeshAgent agent;
    public float attack_distance;
    public float vision_radio;

    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    void Update()
    {
        Enemy_Behaviour();
    }

    public void Enemy_Behaviour()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > vision_radio)
        {
            agent.enabled = false;
            ani.SetBool("run", false);
            stopwatch += 1 * Time.deltaTime;
            if (stopwatch >= 4)
            {
                rutine = Random.Range(0, 2);
                stopwatch = 0;
            }
            switch (rutine)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;

                case 1:
                    grade = Random.Range(0, 360);
                    angle = Quaternion.Euler(0, grade, 0);
                    rutine++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);

            agent.enabled = true;
            agent.SetDestination(target.transform.position);

            if (Vector3.Distance(transform.position, target.transform.position) > attack_distance && !attack)
            {
                ani.SetBool("walk", false);
                ani.SetBool("run", true);
            }
            else
            {
                if (!attack)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 1);
                    ani.SetBool("walk", false);
                    ani.SetBool("run", false);
                }
            }

            if (attack)
            {
                agent.enabled = false;
            }
            /*
            if (Vector3.Distance(transform.position, target.transform.position) > 3 && !attack)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                ani.SetBool("walk", false);

                ani.SetBool("run", true);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);

                ani.SetBool("attack", false);
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                ani.SetBool("walk", false);
                ani.SetBool("run", false);
            }
            */
        }
    }

    public void Final_Ani()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > attack_distance + 0.2f)
        { 
            ani.SetBool("attack", false);
        }
        attack = false;

        range.GetComponent<BoxCollider>().enabled = true;
    }
}
