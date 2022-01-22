using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //NOTE: NOT USED IN THIS PROJECT
    public static EnemyManager enemyManager;
    public GameObject[] spawnPoints;

    void Start()
    {
        SpawnEnemies();
    }

    private void OnEnable()
    {
        EnemyHealth.OnEnemyKilled += SpawnEnemies;
    }

    public void SpawnEnemies()
    {
        //this if for normal instantiating the enemy in random locations
        // GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length-1)];
        // Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
        
        GameObject enemy = ObjectPool.instance.GetPooledObject("Enemy");
        if(enemy != null)
        {
            //added code for the random location where the enemy should spawn with object pooling
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            enemy.transform.position = spawnPoint.transform.position;
            enemy.transform.rotation = spawnPoint.transform.rotation;
            enemy.SetActive(true);
        }
    }
}
