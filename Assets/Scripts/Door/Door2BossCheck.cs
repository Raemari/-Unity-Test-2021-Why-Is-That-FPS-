using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2BossCheck : MonoBehaviour
{
    [SerializeField] GameObject[] enemyBosses;
    public string doorName;
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        //so that enemy cannot be locked when wandering
        if(other.gameObject.tag == "Player")
        {
            for(int i = 0; i < enemyBosses.Length; i++)
            {
                if(enemyBosses[i].activeInHierarchy)
                {
                    GameEvents.instance.DoorWayTriggerLocked(doorName, id);
                    GameEvents.instance.DoorWayTriggerClose(doorName, id);
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
        if(other.gameObject.tag == "Enemy")
        {
            GameEvents.instance.DoorWayTriggerUnlocked(doorName, id);
        }
    }
}
