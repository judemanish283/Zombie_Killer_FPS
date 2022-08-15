using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] int bulletDamage = 10;
    [SerializeField] ParticleSystem muzzleflash;
    //[SerializeField] ParticleSystem projectile;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoslot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float fireRate = 3;
    [SerializeField] TextMeshProUGUI ammoText;
    
    bool canShoot = true;
    

    void OnEnable() 
    {
        canShoot = true;
    } 

    void Update()
    {
        DisplayAmmo();
        if(Input.GetMouseButtonDown(0)&& canShoot)   
        {
            StartCoroutine(Shoot());
        }
        
    }

    private void DisplayAmmo()
    {
        int currentammo = ammoslot.GetCurrentAmmo(ammoType);
        ammoText.text = currentammo.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if((ammoslot.GetCurrentAmmo(ammoType) > 0) )       
        {
            PlayMuzzleFlash();
            ProcessRayCast();
            
        }
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
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
            ammoslot.ReduceCurrentAmmo(ammoType);
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
