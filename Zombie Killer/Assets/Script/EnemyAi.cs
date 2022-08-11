using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    Animator enemyAnimator;
   
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();

    }

    
    void Update()
    {
       distanceToTarget = Vector3.Distance(target.position, transform.position);
       if(isProvoked)
       {
        EngageTarget();
       }
       else if(distanceToTarget > chaseRange)
       {
            isProvoked = false;
            enemyAnimator.SetBool("IsMoving", false);
       }
       else if(distanceToTarget <= chaseRange)
       {
            enemyAnimator.SetBool("IsMoving", true);
            isProvoked = true;
       }
    }

    void EngageTarget()
    {
        if(distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            enemyAnimator.SetBool("IsAttacking", false);
            ChaseTarget();
        }
        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            enemyAnimator.SetBool("IsAttacking", true);
            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        
        Debug.Log("Seeking and destroying");
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);    
    }

    
}
