using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHealth = 100f;
    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }


    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        enemyHealth -= damage;
        if(enemyHealth <= 0)
        {
            EnemyDies();
        }
    }
    private void EnemyDies()
    {
        if(isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("isDead");
    }
}
