using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyHealth = 50;
    
    public void TakeDamage(int damage)
    {
        BroadcastMessage("IsProvoked");
        enemyHealth -= damage;
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
