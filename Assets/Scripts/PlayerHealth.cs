using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth = 100f;
    [SerializeField] TextMeshProUGUI healthText;
    float maxPlayerHealth = 100f;
    bool isHealthMaxed = false;

    private void Update()
    {
        healthText.text = "Health: " + playerHealth.ToString() + "/100";
    }

    public void PlayerTakesDamage(float damage)
    {
        playerHealth -= damage;
        if(playerHealth <= 0)
        {
            GetComponent<DeathHandler>().GameOverScreen();
            Debug.Log("Player DEEEED");
        }
    }
    public void PickupHealth(int additionalHealth)
    {
        //check first if playerhealth is already 100/100
        if(playerHealth == maxPlayerHealth)
        {
            isHealthMaxed = true;
        }
        else
        {
            isHealthMaxed = false;
            playerHealth+=additionalHealth;
        }
    }
}
