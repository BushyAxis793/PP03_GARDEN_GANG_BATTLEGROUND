using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = .5f;

    [SerializeField] Slider diffSlider;
    [SerializeField] float defaultDifficulty = 0f;

    private void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetVolume();
        diffSlider.value = PlayerPrefsController.GetDifficulty();
    }
    private void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found");
        }
    }
    public void SaveSettings()
    {
        PlayerPrefsController.SetVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(diffSlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }
    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        diffSlider.value = defaultDifficulty;
    }
}
