using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    [SerializeField] int additionalHealth = 10;
    [SerializeField] PlayerHealth playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<PlayerHealth>().PickupHealth(additionalHealth);
            GameObject healthPickup = ObjectPool.instance.GetPooledObject("HealthPickup");
            healthPickup.SetActive(false);
        }
    }
}
