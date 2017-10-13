using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour {

    private PlayerController pc;
    private Transform playerTransform;
    private NavMeshAgent nav;
    private Animator animator;
    private float _maxAttackTime = 10;
    private float _attackTime = 0;

    void Awake()
    {
        pc = FindObjectOfType<PlayerController>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.LookAt(playerTransform);
        if (pc.hp > 0)
        {
            animator.SetBool("Run", true);
            nav.SetDestination(playerTransform.position);
            if (Vector3.Distance(transform.position, playerTransform.position) <= 6f)
            {
                animator.SetBool("Run", false);
                animator.SetTrigger("Attack");
            }
        }
        else
        {
            nav.enabled = false;
        }
    }

    public void Hit()
    {
        pc.TakeDamage();
    }
}
