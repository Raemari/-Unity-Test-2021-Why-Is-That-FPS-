using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 20f;
    [SerializeField] PlayerHealth player;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }
    public void NewEvent()
    {
        if(target == null) return;
        target.PlayerTakesDamage(damage);
        target.GetComponent<DisplayDamage>().ShowDamageReceivedUI();
    }
}
