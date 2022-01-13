using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator doorAnim;
    BoxCollider col;
    public string doorName;
    public int id;

    private void Start()
    {
        doorAnim = GetComponent<Animator>();
        col = GetComponent<BoxCollider>();
        GameEvents.instance.OnDoorwayTriggerEnter += OnDoorWayOpen;
        GameEvents.instance.OnDoorWayTriggerExit += OnDoorWayClose;
        GameEvents.instance.OnDoorWayTriggerLocked += OnDoorWayLocked;
        GameEvents.instance.OnDoorWayTriggerUnLocked += OnDoorWayUnlocked;
    }

    private void OnDoorWayOpen(string doorName, int id)
    {
        if(doorName == this.doorName && id == this.id)
        {
            doorAnim.SetBool("character_nearby", true);
            col.enabled = false;
        }
    }
    private void OnDoorWayClose(string doorName, int id)
    {
        if(doorName == this.doorName && id == this.id)
        {
            doorAnim.SetBool("character_nearby", false);
            col.enabled = true;
        }
    }
    private void OnDoorWayLocked(string doorName, int id)
    {
        if(doorName == this.doorName && id == this.id)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            Debug.Log("YOURE LOCKED NEED TO DEFEAT BOSS");
        }
    }
    private void OnDoorWayUnlocked(string doorName, int id)
    {
        if(doorName == this.doorName && id == this.id)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("UNLOCKED");
        }
    }
}
