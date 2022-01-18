using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSaving : MonoBehaviour
{
    private PlayerData playerData;

    private void Start()
    {
        CreatePlayerData();
    }

    private void CreatePlayerData()
    {
        playerData = new PlayerData(200, 5, 20, 1, 2, 1);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        SaveData();
        if(Input.GetKeyDown(KeyCode.L))
        LoadData();
    }
    public void SaveData()
    {
        PlayerPrefs.SetFloat("PlayerHealth", playerData.playerHealth);
        PlayerPrefs.SetInt("Ammo", playerData.ammo);
        PlayerPrefs.SetInt("PickedItems", playerData.pickedItems);
        PlayerPrefs.SetInt("EnemyLives", playerData.enemyLives);
        PlayerPrefs.SetInt("DoorOpened", playerData.doorOpened);
        PlayerPrefs.SetInt("BossKilled", playerData.bossKilled);
    }

    public void LoadData()
    {
        playerData = new PlayerData(PlayerPrefs.GetFloat("PlayerHealth"), PlayerPrefs.GetInt("Ammo"), PlayerPrefs.GetInt("PickedItems"), PlayerPrefs.GetInt("EnemyLives"), PlayerPrefs.GetInt("DoorOpened"), PlayerPrefs.GetInt("BossKilled"));

        Debug.Log(playerData.ToString());
    }
}
