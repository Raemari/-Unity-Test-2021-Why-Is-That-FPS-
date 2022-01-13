using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1BossCheck : MonoBehaviour
{
    GameObject enemyBoss;
    public string doorName;
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        if(enemyBoss.activeInHierarchy)
        {
            GameEvents.instance.DoorWayTriggerClose(doorName, id);
            GameEvents.instance.DoorWayTriggerLocked(doorName, id);
        }
        else
        {
            GameEvents.instance.DoorWayTriggerUnlocked(doorName, id);
        }
    }
}
