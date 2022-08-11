using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] int bulletDamage = 10;
    [SerializeField] ParticleSystem muzzleflash;
    //[SerializeField] ParticleSystem projectile;
    [SerializeField] GameObject hitEffect;

    void Start() 
    {
      
    }
    void Update()
    {
        
        if(Input.GetButtonDown("Fire1"))   
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRayCast();
    }

    void PlayMuzzleFlash()
    {
        muzzleflash.Play();
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeDamage(bulletDamage);

        }
        else
        {
            return;
        }
    }

    void CreateHitImpact(RaycastHit hit)
    {
        GameObject instance = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(instance, .1f);
    }
}
