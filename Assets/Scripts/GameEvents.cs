using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;
    private void Awake()
    {
        instance = this;
    }
    public event Action<string, int> OnDoorwayTriggerEnter;
    public event Action<string, int> OnDoorWayTriggerExit;
    public event Action<string, int> OnDoorWayTriggerLocked;
    public event Action<string, int> OnDoorWayTriggerUnLocked;

    public void DoorWayTriggerEnter(string doorName, int id) => OnDoorwayTriggerEnter?.Invoke(doorName, id);
    public void DoorWayTriggerClose(string doorName, int id) => OnDoorWayTriggerExit?.Invoke(doorName, id);
    public void DoorWayTriggerLocked(string doorName, int id) => OnDoorWayTriggerLocked?.Invoke(doorName, id);
    public void DoorWayTriggerUnlocked(string doorName, int id) => OnDoorWayTriggerUnLocked?.Invoke(doorName, id);
}
