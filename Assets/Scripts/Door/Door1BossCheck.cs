using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1BossCheck : MonoBehaviour
{
    [SerializeField] GameObject enemyBoss;
    public string doorName;
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        if(enemyBoss.activeInHierarchy)
        {
            GameEvents.instance.DoorWayTriggerClose(doorName, id);
            GameEvents.instance.DoorWayTriggerLocked(doorName, id);
            //AudioManager.instance.Play("locked");
            GameManager.GM.PlayDoorLocked();
        }
        else
        {
            GameEvents.instance.DoorWayTriggerUnlocked(doorName, id);
            //AudioManager.instance.Play("unlocked");
            GameManager.GM.PlayDoorUnlocked();
        }
    }
}
