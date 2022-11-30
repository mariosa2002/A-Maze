using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator ani;

    void Start()
    {

        ani = GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetTrigger("jump");
        }

        if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.W))
        {
            ani.SetTrigger("forward");
        }
    }
}