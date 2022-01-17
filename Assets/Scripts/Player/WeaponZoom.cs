using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] FirstPersonController fpsController;
    
    [SerializeField] float zoomedInFOV = 15f;
    [SerializeField] float zoomedOutFOV = 60f;


    [SerializeField] float zoomedInSensitivity = .5f;
    [SerializeField] float zoomedOutSensitivity = 2f;

    bool zoomedInToggle = false;

    private void OnDisable()
    {
        ZoomOut();
    }

    private void Update()
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
    private void ZoomIn()
    {
        zoomedInToggle = true;
        fpsCamera.fieldOfView = zoomedInFOV;
        fpsController.m_MouseLook.XSensitivity = zoomedInSensitivity;
        fpsController.m_MouseLook.YSensitivity = zoomedInSensitivity;
    }
    private void ZoomOut()
    {
        zoomedInToggle = false;
        fpsCamera.fieldOfView = zoomedOutFOV;
        fpsController.m_MouseLook.XSensitivity = zoomedOutSensitivity;
        fpsController.m_MouseLook.YSensitivity = zoomedOutSensitivity;
    }
}
