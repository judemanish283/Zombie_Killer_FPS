using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    
    
    
    // Start is called before the first frame update
    public void TakeDamage(float damage)
    {
        health -= damage;
        
        if(health <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();  
        }
    }

    
}
