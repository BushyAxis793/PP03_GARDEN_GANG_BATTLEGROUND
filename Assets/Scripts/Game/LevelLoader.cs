using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int waitInSeconds = 4;
    int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }
    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(waitInSeconds);
        LoadNextScene();
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadLoseScreen()
    {
        SceneManager.LoadScene("Lose Screen");
    }
    public void RestartScene()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
        Debug.Log(PlayerPrefsController.GetDifficulty());
    }
    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Screen");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
