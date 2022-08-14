using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    //[SerializeField] TextMeshProUGUI ammoText;
    
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammo;
    }

    void Start() 
    {
        //ammoText.text = ammoAmount.ToString();
    }

    void Update() 
    {
        // ammoText.text = ammoAmount.ToString();
        
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
