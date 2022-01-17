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
    }
    private void OnTriggerExit(Collider other)
    {
        GameEvents.instance.DoorWayTriggerClose(doorName, id);
    }
}
