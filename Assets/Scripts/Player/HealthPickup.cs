using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] int additionalHealth = 10;
    [SerializeField] PlayerManager playerManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<PlayerManager>().PickupHealth(additionalHealth);
            Destroy(gameObject);
        }
    }
}
