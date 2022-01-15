using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    EnemyHealth enemyHealth;
    private void Start()
    {
        enemyHealth = FindObjectOfType<EnemyHealth>();
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
            {
                other.GetComponentInChildren<DeathHandler>().GameOverScreen();
                break;
            }
            case "Enemy":
            {
                other.GetComponentInChildren<EnemyHealth>().EnemyDies();
                break;
            }

        }
    }
}