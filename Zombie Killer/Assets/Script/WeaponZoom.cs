using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField]Camera gameCamera;
    [SerializeField] int normalFOV = 60;
    [SerializeField] int scopedFOV = 25;

    bool zoomedInToggle;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                zoomedInToggle = true;
                gameCamera.fieldOfView = scopedFOV;
            }
            else
            {
                zoomedInToggle = false;
                gameCamera.fieldOfView = normalFOV;
            }
        }
        
    }
}
