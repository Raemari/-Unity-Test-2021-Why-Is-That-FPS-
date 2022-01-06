using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    [SerializeField] float lightFade = .1f;
    [SerializeField] float angleFade = 1f;
    [SerializeField] float minAngle = 40f;
    float timeLeft;

    Light myLight;

    private void Start()
    {
        myLight = GetComponent<Light>();
    }
    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }
    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }
    public void AddLightIntensity(float intensityAmount)
    {
        myLight.intensity += intensityAmount;
    }

    private void DecreaseLightAngle()
    {
        //To prevent the angle for reaching the lowest value
        if (myLight.spotAngle <= minAngle)
        {
            return;
        }
        else
        {
            myLight.spotAngle -= angleFade * Time.deltaTime;
        }
    }

    private void DecreaseLightIntensity()
    {
        myLight.intensity -= lightFade * Time.deltaTime;
    }
}
