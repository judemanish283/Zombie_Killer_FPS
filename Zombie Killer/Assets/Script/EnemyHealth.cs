using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyHealth = 50;

    public bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }
    
    public void TakeDamage(int damage)
    {
        BroadcastMessage("IsProvoked");
        enemyHealth -= damage;
        if(enemyHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if(isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("IsDying");
        Destroy(gameObject, 10f);
    }
}
