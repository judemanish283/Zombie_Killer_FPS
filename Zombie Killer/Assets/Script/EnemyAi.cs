using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    
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
            enemyAnimator.SetTrigger("Idle");
       }
       else if(distanceToTarget <= chaseRange)
       {
            isProvoked = true;   
       }
    }

    void EngageTarget()
    {
        FaceTarget();
        if(distanceToTarget >= navMeshAgent.stoppingDistance)
        { 
            ChaseTarget();
        }
        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            
            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        enemyAnimator.SetBool("IsAttacking", false);
        enemyAnimator.SetBool("IsMoving", true);
        navMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        
        enemyAnimator.SetBool("IsMoving", false);
        enemyAnimator.SetBool("IsAttacking", true);
        
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);    
    }

    public void IsProvoked()
    {
        isProvoked = true;
    }
    

    
}
