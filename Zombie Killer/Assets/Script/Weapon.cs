using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] int bulletDamage = 10;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))   
        {
            Shoot();
        }
    }

    void Shoot()
   {
        RaycastHit hit;
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward,out hit, range))
        {
            Debug.Log("I Hit: " + hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if(target == null){return;}
            target.TakeDamage(bulletDamage);
            
        }
        else
        {
            return;
        }
   }

   
}
