using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleActivate : MonoBehaviour
{
    [SerializeField] ParticleSystem pickupParticle;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pickupParticle.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        pickupParticle.Stop();
    }
    
}
