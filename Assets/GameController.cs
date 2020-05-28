using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    int numberOfEnemies = 0;
    bool timerFinished = false;
    [SerializeField] GameObject winLabel;
    [SerializeField] float waitForLoad = 4f;

    private void Start()
    {
        winLabel.SetActive(false);
    }

    public void EnemySpawn()
    {
        numberOfEnemies++;
    }
    public void EnemyKilled()
    {
        numberOfEnemies--;
        if (numberOfEnemies <= 0 && timerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitForLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void TimerFinished()
    {
        timerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        EnemySpawnController[] spawnerArray = FindObjectsOfType<EnemySpawnController>();
        foreach (EnemySpawnController spawner in spawnerArray)
        {
            spawner.StopSpawnEnemy();
        }
    }
}
