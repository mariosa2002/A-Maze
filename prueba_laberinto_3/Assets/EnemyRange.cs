using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public Animator ani;
    public EnemyBehaviour enemigo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            ani.SetBool("walk",false);
            ani.SetBool("run", false);
            ani.SetBool("attack", true);
            enemigo.attack = true;
            GetComponent<BoxCollider>().enabled = false;
            print("ataca a jugador");
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
