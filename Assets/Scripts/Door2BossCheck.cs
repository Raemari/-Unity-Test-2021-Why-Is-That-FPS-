using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2BossCheck : MonoBehaviour
{
    [SerializeField] GameObject[] enemyBosses;
    public string doorName;
    public int id;

    private void OnCollisionEnter(Collision other)
    {
        for(int i = 0; i < enemyBosses.Length; i++)
        {
            if(enemyBosses[i].activeInHierarchy)
            {
                GameEvents.instance.DoorWayTriggerLocked(doorName, id);
            }
            else
            {
                GameEvents.instance.DoorWayTriggerUnlocked(doorName, id);
            }
        }
        return;
    }
}
