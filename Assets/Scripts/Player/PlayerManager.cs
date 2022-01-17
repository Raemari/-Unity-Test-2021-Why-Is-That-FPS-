using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//PlayerHealth and management of AMMO
public class PlayerManager : MonoBehaviour
{
    private int playerHealth = 100;
    private int maxPlayerHealth = 100;
    private int additionalHealth = 10;
    [SerializeField] TextMeshProUGUI healthText;

    [SerializeField] Transform weaponIterate;
    Weapon weapon;

    [SerializeField] GameObject pauseCanvas;
    bool isGamePaused;

    bool isHealthMaxed = false;

    private void Start()
    {
        weapon = GetComponentInChildren<Weapon>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = !isGamePaused;
            PauseGame();
        }
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
        if(playerHealth <= maxPlayerHealth)
        {
            playerHealth+=additionalHealth;
        }
        if(playerHealth > maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
        }
    }
    public void PauseGame()
    {
        //data should be saved every time pause game is clicked
        if(isGamePaused)
        {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            //try if i can use GetComponentInChildren
            FindObjectOfType<WeaponSwitcher>().enabled = false;
        }
        else
        {
            ResumeGameFromPause();
        }
    }
    public void ResumeGameFromPause()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        //try if i can use GetComponentInChildren
        FindObjectOfType<WeaponSwitcher>().enabled = true;
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
                        GameObject bulletPickup = ObjectPool.instance.GetPooledObject("PickupAmmo");
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
                        GameObject shellsPickup = ObjectPool.instance.GetPooledObject("PickupShells");
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
                        GameObject pickupRocket = ObjectPool.instance.GetPooledObject("PickupRocket");
                        other.gameObject.SetActive(false);
                    }
                    break;
                }
            }
        }
    }
}
