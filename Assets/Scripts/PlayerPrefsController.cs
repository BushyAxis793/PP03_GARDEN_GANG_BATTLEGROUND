using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string VOLUME_KEY = "volume";
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const string DIFFICULTY_KEY = "difficulty";
    const float MIN_DIFF = 0f;
    const float MAX_DIFF = 2f;

    public static void SetVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {

            PlayerPrefs.SetFloat(VOLUME_KEY, volume);
        }
        else
        {
            //DO NOTHING
        }
    }
    public static float GetVolume()
    {
        return PlayerPrefs.GetFloat(VOLUME_KEY);
    }

    public static void SetDifficulty(float diff)
    {
        if (diff >= MIN_DIFF && diff <= MAX_DIFF)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, diff);
        }
        else
        {
            //DO NOTHING
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

}
