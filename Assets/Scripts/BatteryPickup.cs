using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 90f;
    [SerializeField] float addIntensity = 1f;

    private void OnTriggerEnter(Collider other)
    {
        //Use GetComponentInChildren because flashlight is inside player
        //player is now "other"
        if(other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashlightSystem>().RestoreLightAngle(restoreAngle);
            other.GetComponentInChildren<FlashlightSystem>().AddLightIntensity(addIntensity);
            Destroy(gameObject);
        }
    }
}
