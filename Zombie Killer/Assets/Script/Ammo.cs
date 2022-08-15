using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    
    
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammo;
       
    }

    void Start() 
    {
         
    }

    void Update() 
    {
                
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammo;
    }

    

    public void ReduceCurrentAmmo(AmmoType ammoType)
    { 
       GetAmmoSlot(ammoType).ammo--;  
    }

    public void IncreaseAmmo(AmmoType ammoType, int ammoAdd)
    {
         GetAmmoSlot(ammoType).ammo += ammoAdd;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
