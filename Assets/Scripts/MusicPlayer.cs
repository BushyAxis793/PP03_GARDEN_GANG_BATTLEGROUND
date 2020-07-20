using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        int numOfPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (numOfPlayers > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetVolume();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
