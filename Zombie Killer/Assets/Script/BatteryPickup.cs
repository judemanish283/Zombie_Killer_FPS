using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float angleamount = 70f;
    [SerializeField] float intensityamount = 1.5f;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            other.GetComponentInChildren<FlashLight>().RestoreLight(angleamount, intensityamount);
            Destroy(gameObject);
        }  
          return;  
    }
}
