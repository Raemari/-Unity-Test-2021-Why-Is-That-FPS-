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
            //AudioManager.instance.Play("door");
            GameManager.GM.PlayDoorOpen();
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
        }
    }
    private void OnDoorWayUnlocked(string doorName, int id)
    {
        if(doorName == this.doorName && id == this.id)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void OnDisable()
    {
        GameEvents.instance.OnDoorwayTriggerEnter -= OnDoorWayOpen;
        GameEvents.instance.OnDoorWayTriggerExit -= OnDoorWayClose;
        GameEvents.instance.OnDoorWayTriggerLocked -= OnDoorWayLocked;
        GameEvents.instance.OnDoorWayTriggerUnLocked -= OnDoorWayUnlocked;
    }
}
