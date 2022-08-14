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
    public bool zoomedInToggle;

    private void OnDisable() 
    {
        ZoomOut();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
        
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        gameCamera.fieldOfView = normalFOV;
        fpscontroller.mouseLook.XSensitivity = 2;
        fpscontroller.mouseLook.YSensitivity = 2;
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        gameCamera.fieldOfView = scopedFOV;
        fpscontroller.mouseLook.XSensitivity = zoomedInSensitivity;
        fpscontroller.mouseLook.YSensitivity = zoomedInSensitivity;
    }
}
