using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;
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
    public void EnemyDies()
    {
        if(isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("isDead");

        if(gameObject.tag == "Enemy" || gameObject.tag == "EnemyBoss")
        {
            gameObject.SetActive(false);

            if(OnEnemyKilled != null)
            {
                OnEnemyKilled();
            }
        }
        // if(gameObject.tag == "EnemyBoss")
        // {
        //     gameObject.SetActive(false);

        //     if(OnEnemyKilled != null)
        //     {
        //         OnEnemyKilled();
        //     }
        // }

    }
}
