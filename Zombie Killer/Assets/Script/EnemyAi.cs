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
    EnemyHealth health;
    
   
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
    }

    
    void Update()
    {
        if(health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
       distanceToTarget = Vector3.Distance(target.position, transform.position);
       if(isProvoked)
       {
        EngageTarget();
       }
       else if(distanceToTarget > chaseRange)
       {
            isProvoked = false;
            GetComponent<Animator>().SetTrigger("Idle");
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
        GetComponent<Animator>().SetBool("IsAttacking", false);
        GetComponent<Animator>().SetBool("IsMoving", true);
        navMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        
        GetComponent<Animator>().SetBool("IsMoving", false);
       GetComponent<Animator>().SetBool("IsAttacking", true);
        
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
