using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;
    private bool isAmmoMaxed = true;
    //shows the content that belongs to this class
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmmount;
        public int maxAmmo;
    }
    private void Start()
    {
        isAmmoMaxed = true;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmmount;
    }
    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmmount--;
    }
    public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount, int maxAmmo)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if(slot.maxAmmo == maxAmmo)
            {
                isAmmoMaxed = true;
            }
            else
            {
                isAmmoMaxed = false;
                GetAmmoSlot(ammoType).ammoAmmount+= ammoAmount;
                Debug.Log("IncreaseCurrentAmmo if !isAmmoMAxed");
            }
        }
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
    // private AmmoSlot GetMaxAmmo(int maxAmmo)
    // {
    //     foreach (AmmoSlot slot in ammoSlots)
    //     {
    //         if(slot.maxAmmo == maxAmmo)
    //         {
    //             isAmmoMaxed = true;
    //             return slot;
    //             Debug.Log("XHECK get max ammo function IS TRUE");
    //         }
    //         else
    //         {
    //             isAmmoMaxed = false;
    //             Debug.Log("XHECK get max ammo function");
    //         }
    //     }
    //     return null;
    // }

}
