using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public string doorName;
    public int id;
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.instance.DoorWayTriggerEnter(doorName, id);
        //only the player can trigger the enter sound
        if(other.gameObject.tag == "Player")
        {
            GameManager.GM.PlayDoorOpen();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameEvents.instance.DoorWayTriggerClose(doorName, id);
    }
}
