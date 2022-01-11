using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    private int maxAmmo;
    [SerializeField] AmmoType ammoType;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmount, maxAmmo);
            Destroy(gameObject);
        }
    }
}
