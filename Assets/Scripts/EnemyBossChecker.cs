using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossChecker : MonoBehaviour
{
    //script for door1
    public GameObject enemyBoss;
    public bool enemyBossAlive = true;

    private void OnTriggerEnter(Collider other)
    {
        if(enemyBoss.activeInHierarchy)
        {
            enemyBossAlive = true;
            GameEvents.instance.DoorWayTriggerClose();
            GameEvents.instance.DoorWayTriggerLocked();
        }
        else
        {
            enemyBossAlive = false;
            GameEvents.instance.DoorWayTriggerUnlocked();
        }
    }
}
