using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    int numberOfEnemies = 0;
    bool timerFinished = false;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] GameObject pauseLabel;
    [SerializeField] float waitForLoad = 4f;

    bool isPaused;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    private void Update()
    {
        PauseGame();
    }

    public void EnemySpawned()
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

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        GameObject.Find("Game UI").SetActive(false);
        Time.timeScale = 0;
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

    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                Time.timeScale = 0;
                pauseLabel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseLabel.SetActive(false);
            }
        }
    }
}
