using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int lives = 5;
    [SerializeField] int damage = 1;
    TextMeshProUGUI livesText;

    private void Start()
    {
        livesText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void ReduceLives()
    {
        lives -= damage;
        UpdateDisplay();

        if (lives <= 0)
        {
            FindObjectOfType<LevelLoader>().LoadLoseScreen();
        }
    }
}
