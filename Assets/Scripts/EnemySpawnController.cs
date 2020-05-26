using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 1f;
    [SerializeField] EnemyController enemyPrefab;

    bool spawn = true;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnTime, maxSpawnTime));
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        EnemyController newEnemy =  Instantiate(enemyPrefab, transform.position, transform.rotation) as EnemyController;

        newEnemy.transform.parent = transform;
    }
}
