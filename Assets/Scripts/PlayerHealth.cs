using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth = 100f;

    public void PlayerTakesDamage(float damage)
    {
        playerHealth -= damage;
        if(playerHealth <= 0)
        {
            GetComponent<DeathHandler>().GameOverScreen();
            Debug.Log("Player DEEEED");
        }
    }
}
