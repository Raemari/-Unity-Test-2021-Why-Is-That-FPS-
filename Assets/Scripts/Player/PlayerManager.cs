using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//PlayerHealth and management of AMMO
public class PlayerManager : MonoBehaviour
{
    [SerializeField] int playerHealth = 100;
    [SerializeField] int maxPlayerHealth = 100;
    [SerializeField] int additionalHealth = 10;
    [SerializeField] TextMeshProUGUI healthText;

    [SerializeField] Transform weaponIterate;
    Weapon weapon;


    private void Start()
    {
        weapon = GetComponentInChildren<Weapon>();
    }

    private void Update()
    {
        healthText.text = "Health: " + playerHealth.ToString() + "/100";
    }

    public void PlayerTakesDamage(int damage)
    {
        playerHealth -= damage;
        //AudioManager.instance.Play("playerTakesDamage");
        GameManager.GM.PlayHurt();
        if(playerHealth <= 0)
        {
            GetComponent<DeathHandler>().GameOverScreen();
            Debug.Log("Player DEEEED");
        }
    }
    public void PickupHealth(int additionalHealth)
    {
        //check first if playerhealth is already 100/100
        if(playerHealth <= maxPlayerHealth)
        {
            playerHealth+=additionalHealth;
        }
        if(playerHealth > maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //iterate in the child of "weapons"
        for(int i =0; i < weaponIterate.childCount; i++)
        {
            //checks the tag of the pickup object
            //check if i can pool the pick ups
            switch(other.gameObject.tag)
            {
                case "PickupAmmo":
                {
                    if(weaponIterate.GetChild(i).name == "Gun")
                    {
                        weaponIterate.GetChild(i).GetComponent<Weapon>().IncreaseMagazine();
                        Debug.Log("GET CURRENT AMMO AMOUNT GUUUN++");
                        Destroy(other.gameObject);
                        // GameObject bulletPickup = ObjectPool.instance.GetPooledObject("PickupAmmo");
                        // other.gameObject.SetActive(false);
                    }
                    break;
                }
                case "PickupShells":
                {
                    if(weaponIterate.GetChild(i).name == "SciFiGun_Specular")
                    {
                        weaponIterate.GetChild(i).GetComponent<Weapon>().IncreaseMagazine();
                        Debug.Log("GET CURRENT AMMO AMOUNT SICIFIGUN++");
                        Destroy(other.gameObject);
                        // GameObject shellsPickup = ObjectPool.instance.GetPooledObject("PickupShells");
                        // other.gameObject.SetActive(false);
                    }
                    break;
                }
                case "PickupRocket":
                {
                    if(weaponIterate.GetChild(i).name == "Carbine")
                    {
                        weaponIterate.GetChild(i).GetComponent<Weapon>().IncreaseMagazine();
                        Debug.Log("GET CURRENT AMMO AMOUNT CARBINE++");
                        Destroy(other.gameObject);
                        // GameObject pickupRocket = ObjectPool.instance.GetPooledObject("PickupRocket");
                        // other.gameObject.SetActive(false);
                    }
                    break;
                }
            }
        }
    }
}
