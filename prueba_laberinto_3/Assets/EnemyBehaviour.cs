using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public float alertRange;
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
    }
}
