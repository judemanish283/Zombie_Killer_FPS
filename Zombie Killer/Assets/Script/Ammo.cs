using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 100;
    [SerializeField] TextMeshProUGUI ammoText;
    
    void Start() 
    {
        ammoText.text = ammoAmount.ToString();
    }

    void Update() 
    {
         ammoText.text = ammoAmount.ToString();
    }

    public int GetCurrentAmmo()
    {
        return ammoAmount;
        
    }

    public void ReduceCurrentAmmo()
    {
        
        ammoAmount--;
        
    }
}
