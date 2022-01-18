using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public float playerHealth;
    public int ammo;

    public int pickedItems;

    public int enemyLives;
    public int doorOpened;
    public int bossKilled;

    public PlayerData(float playerHealth, int ammo, int pickedItems, int enemyLives, int doorOpened, int bossKilled)
    {
        this.playerHealth = playerHealth;
        this.ammo = ammo;
        this.pickedItems = pickedItems;
        this.enemyLives = enemyLives;
        this.doorOpened = doorOpened;
        this.bossKilled = bossKilled;
    }
    public override string ToString()
    {
        return $"{playerHealth}, has {ammo} and has {pickedItems}. {enemyLives} and killed, {doorOpened} that has killed {bossKilled}";
    }
}
