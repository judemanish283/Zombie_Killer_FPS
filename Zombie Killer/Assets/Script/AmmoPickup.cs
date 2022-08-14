using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAdd = 15;
    [SerializeField] AmmoType ammoType;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Ammo>().IncreaseAmmo(ammoType, ammoAdd);
            Destroy(gameObject);
        }
    }
}
