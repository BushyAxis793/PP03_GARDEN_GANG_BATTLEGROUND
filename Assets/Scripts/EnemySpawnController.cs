using System.Collections;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 1f;
    [SerializeField] EnemyController[] enemyPrefabArray;

    bool spawn = true;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            SpawnEnemy();
        }
    }

    public void StopSpawnEnemy()
    {
        spawn = false;
    }

    private void SpawnEnemy()
    {
        var enemyIndex = Random.Range(0, enemyPrefabArray.Length);
        Spawn(enemyPrefabArray[enemyIndex]);
    }

    private void Spawn(EnemyController enemy)
    {
        EnemyController newEnemy = Instantiate(enemy, transform.position, transform.rotation) as EnemyController;

        newEnemy.transform.parent = transform;
    }
}
