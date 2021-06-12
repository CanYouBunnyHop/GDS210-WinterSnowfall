using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Gamemaster gm;
    private Animator ani;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Gamemaster>();
        ani = GetComponent<Animator>();
        
    }
    void Update()
    {
        CheckIfCheckPointIsActive();
    }
      void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            gm.lastCheckPointPos = transform.position;
        }
    }
    void CheckIfCheckPointIsActive()
    {
        if(gm.lastCheckPointPos == transform.position)
        {
            ani.SetBool("PlayerEnters", true);
        }
        else
        {
             ani.SetBool("PlayerEnters", false);
        }
    }
}
