using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class WeaponZoom : MonoBehaviour
{
    [SerializeField]Camera gameCamera;
    [SerializeField] int normalFOV = 60;
    [SerializeField] int scopedFOV = 25;
    [SerializeField] float zoomedInSensitivity = 1f;

    [SerializeField] RigidbodyFirstPersonController fpscontroller;
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
                fpscontroller.mouseLook.XSensitivity = zoomedInSensitivity;
                fpscontroller.mouseLook.YSensitivity = zoomedInSensitivity;
            }
            else
            {
                zoomedInToggle = false;
                gameCamera.fieldOfView = normalFOV;
                fpscontroller.mouseLook.XSensitivity = 2;
                fpscontroller.mouseLook.YSensitivity = 2;
            }
        }
        
    }
}
