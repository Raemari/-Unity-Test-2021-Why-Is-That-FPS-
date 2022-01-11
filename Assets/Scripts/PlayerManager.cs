using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//PlayerHealth and management of AMMO
public class PlayerManager : MonoBehaviour
{
    private int playerHealth = 100;
    private int maxPlayerHealth = 100;
    [SerializeField] TextMeshProUGUI healthText;

    [SerializeField] Transform weaponIterate;
    Weapon weapon;

    bool isHealthMaxed = false;

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
        AudioManager.instance.Play("playerTakesDamage");
        if(playerHealth <= 0)
        {
            GetComponent<DeathHandler>().GameOverScreen();
            Debug.Log("Player DEEEED");
        }
    }
    public void PickupHealth(int additionalHealth)
    {
        //check first if playerhealth is already 100/100
        if(playerHealth > maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
            isHealthMaxed = true;
        }
        else
        {
            isHealthMaxed = false;
            playerHealth+=additionalHealth;
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
                        other.gameObject.SetActive(false);
                    }
                    break;
                }
                case "PickupShells":
                {
                    if(weaponIterate.GetChild(i).name == "SciFiGun_Specular")
                    {
                        weaponIterate.GetChild(i).GetComponent<Weapon>().IncreaseMagazine();
                        Debug.Log("GET CURRENT AMMO AMOUNT SICIFIGUN++");
                        other.gameObject.SetActive(false);
                    }
                    break;
                }
                case "PickupRocket":
                {
                    if(weaponIterate.GetChild(i).name == "Carbine")
                    {
                        weaponIterate.GetChild(i).GetComponent<Weapon>().IncreaseMagazine();
                        Debug.Log("GET CURRENT AMMO AMOUNT CARBINE++");
                        other.gameObject.SetActive(false);
                    }
                    break;
                }
            }
        }
    }
}
    // public void GetCurrentMagazineAmount()
    // {
    //     for(int i =0; i < weaponIterate.childCount; i++)
    //     {
    //         if(weaponIterate.GetChild(i).name == "Gun")
    //         {
    //              gun = weaponIterate.GetChild(i).GetComponent<Weapon>().IncreaseMagazine();
    //             varGun = gun;
                
    //             Debug.Log("GET CURRENT AMMO AMOUNT GUUUN++");
    //         }
    //         if(weaponIterate.GetChild(i).name == "SciFiGun_Specular")
    //         {
    //             var varscifiGun = weaponIterate.GetChild(i).GetComponent<Weapon>().magazineSize++;
    //             Debug.Log("GET CURRENT AMMO AMOUNT SICIFIGUN++");
    //         }
    //         if(weaponIterate.GetChild(i).name == "Carbine")
    //         {
    //             var varcarbine = weaponIterate.GetChild(i).GetComponent<Weapon>().magazineSize++;
    //             Debug.Log("GET CURRENT AMMO AMOUNT CARBINE++");
    //         }
    //     }
    // }